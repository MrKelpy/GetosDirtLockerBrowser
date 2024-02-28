using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetosDirtLocker.utils;
using LaminariaCore_Databases.sqlserver;

namespace GetosDirtLocker.gui
{
    /// <summary>
    /// The main interface for adding new dirt into the locker. Also displays the last few entries.
    /// </summary>
    public partial class LockerAdditionInterface : Form
    {
        
        /// <summary>
        /// The database manager used to access and interact with the db
        /// </summary>
        private SQLDatabaseManager Database { get; }

        /// <summary>
        /// The dirt manager used to download and cache pictures relative to dirt
        /// </summary>
        private DirtStorageManager DirtManager { get; }
        
        /// <summary>
        /// Main constructor of the class
        /// </summary>
        /// <param name="manager">The database manager used to access and interact with the db</param>
        public LockerAdditionInterface(SQLDatabaseManager manager)
        {
            InitializeComponent();
            PictureLoading.SizeMode = PictureBoxSizeMode.Zoom;
            this.Database = manager;
            this.DirtManager = new DirtStorageManager(Database);
            
            GridDirt.RowTemplate.Height = 100;
            GridDirt.ClearSelection();
        }

        /// <returns>
        /// Returns the frame of the form, containing all the elements.
        /// </returns>
        public Panel GetLayout() => this.Frame;
        
        /// <summary>
        /// Add the last few entries to the DataGridView.
        /// </summary>
        public async void ReloadEntries()
        { 
            // Get all the dirt entries existent in the database and initialise an array for the rows
            Mainframe.Instance.reloadEntriesToolStripMenuItem.Available = false;
            
            List<string[]> dirtEntries = this.Database.Select("Dirt");
            List<Task> tasklist = new List<Task>();  // The list of contents to add in tasks
            
            dirtEntries.Reverse();
            GridDirt.Rows.Clear();
            
            for (int i = 0; i < 3; i++)
            {
                // If there are no more entries, break the loop. If there are, add the adder task into the list.
                if (i >= dirtEntries.Count) break;
                string[] entry = dirtEntries[i];

                tasklist.Add(ProcessEntryAddition(entry));
            }

            await Task.WhenAll(tasklist);
            Mainframe.Instance.reloadEntriesToolStripMenuItem.Available = true;
        }
        
        /// <summary>
        /// Handles the asynchronous addition of content into the DataGridView
        /// </summary>
        /// <param name="entry">The entry information to add into the grid</param>
        private async Task ProcessEntryAddition(string[] entry)
        {
            DiscordUser user = new DiscordUser(entry[1]);

            string informationString = user.GetInformationString(this.Database, entry[0]);
                
            // Gets the attachment ID from the indexation ID
            List<string[]> result = this.Database.Select(["attachment_id"], "Dirt", $"indexation_id = '{entry[0]}'");
            string dirtPath = await DirtManager.GetDirtPicture(result[0][0]);
                
            // Creates a DataGridViewRow and add it to the gridContents array
            GridDirt.Rows.Add( entry[0], entry[1], Image.FromFile(await user.GetUserAvatar()), informationString, Image.FromFile(dirtPath));
        }

        /// <summary>
        /// Adds a new dirt entry to the locker based on the provided data.
        /// </summary>
        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            GeneralErrorProvider.Clear();
            DiscordUser user = new DiscordUser(TextBoxUserUUID.Text);
            
            // Checks if the user UUID is empty.
            if (!await user.CheckAccountExistence())
            {
                GeneralErrorProvider.SetError(TextBoxUserUUID, "This user does not exist.");
                return;
            }

            // Checks if the URL is a valid url
            if (!Uri.IsWellFormedUriString(TextBoxAttachmentURL.Text, UriKind.Absolute))
            {
                GeneralErrorProvider.SetError(TextBoxAttachmentURL, "This URL is not valid.");
                return;
            }

            user.AddToDatabase(this.Database);  // Adds the user to the database if they don't exist.
            
            string indexationID = user.GetNextIndexationID(this.Database);
            string username = user.TryGetAdocordUsername() == "" ? (await user.GetUserFromID()).Username : "Unknown";
            
            // Gets the file type and size of the attachment
            using WebResponse response = await WebRequest.Create(TextBoxAttachmentURL.Text).GetResponseAsync();
            string fileType = response.ContentType;
            long fileSize = response.ContentLength;
            
            // Inserts the attachment into the database and then the dirt entry.
            this.Database.InsertInto("Attachment", fileType, TextBoxAttachmentURL.Text, fileSize);
            string attachmentID = this.Database.Select(["attachment_id"], "Attachment", $"attachment_url = '{TextBoxAttachmentURL.Text}'")[0][0];
            
            this.Database.InsertInto("Dirt", indexationID, user.Uuid.ToString(), int.Parse(attachmentID), username, TextBoxAdditionalNotes.Text);
            user.IncrementTotalDirtCount(this.Database);
            
            // Builds the information string
            string informationString = user.GetInformationString(this.Database, indexationID);
            
            // Inserts the dirt entry into the DataGridView
            string dirtPath = DirtManager.GetDirtPicturePath(attachmentID);
            GridDirt.Rows.Add(indexationID, user.Uuid, Image.FromFile(await user.DownloadUserAvatar()), informationString, Image.FromFile(dirtPath));
        }

        /// <summary>
        /// Keeps clearing the selection on the DataGridView so that it never displays a blue selected colour on it.
        /// </summary>
        private void GridDirt_SelectionChanged(object sender, EventArgs e) => GridDirt.ClearSelection();

        /// <summary>
        /// Copies the content inside any of the information column cells showing a "copied to clipboard" prompt
        /// followed by the reposition of the original content.
        /// </summary>
        private async void GridDirt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3) return;

            // Gets the clicked cell and the relevant contents
            DataGridViewCell cell = GridDirt.Rows[e.RowIndex].Cells[3];
            string originalContent = cell.Value.ToString();

            if (originalContent == "Copied to Clipboard") return;
            
            string userId = GridDirt.Rows[e.RowIndex].Cells[1].Value.ToString();
            string indexationId = GridDirt.Rows[e.RowIndex].Cells[0].Value.ToString();
            DiscordUser user = new DiscordUser(userId);
            
            // Gets the information formatted in the discord-pasteeable format
            string information = user.GetInformationString(this.Database, indexationId, true);
            Clipboard.SetData(DataFormats.Text, information);

            cell.Value = "Copied to Clipboard";
            await Task.Delay(1 * 1000);
            cell.Value = originalContent;
        }
    }
}