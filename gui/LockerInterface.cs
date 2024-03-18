using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetosDirtLockerBrowser.Properties;
using GetosDirtLockerBrowser.requests;
using GetosDirtLockerBrowser.utils;
using LaminariaCore_Databases.sqlserver;

namespace GetosDirtLockerBrowser.gui
{
    /// <summary>
    /// The main interface for the display of dirt into the locker.
    /// </summary>
    public partial class LockerInterface : Form
    {

        /// <summary>
        /// The dirt manager used to download and cache pictures relative to dirt
        /// </summary>
        private DirtStorageManager DirtManager { get; }
        
        /// <summary>
        /// The image accessor used to manage the images in the database
        /// </summary>
        private DatabaseImageAccessor ImageAccessor { get; }
        
        /// <summary>
        /// The currently selected row in the DataGridView
        /// </summary>
        private DataGridViewRow SelectedRow { get; set; }
        
        /// <summary>
        /// Main constructor of the class
        /// </summary>
        public LockerInterface()
        {
            InitializeComponent();
            this.DirtManager = new DirtStorageManager();
            this.ImageAccessor = new DatabaseImageAccessor();
            
            GridDirt.RowTemplate.Height = 100;
            GridDirt.ClearSelection();
        }

        /// <returns>
        /// Returns the frame of the form, containing all the elements.
        /// </returns>
        public Panel GetLayout() => this.Frame;

        /// <summary>
        /// Returns the list of entries allowed to be displayed based on the set filters
        /// </summary>
        /// <returns>The list of rows to add to the database</returns>
        private List<string[]> GetFilteredEntries()
        {
            SQLDatabaseManager database = Program.CreateManagerFromCredentials(Program.DefaultHost, Program.DefaultCredentials);
            
            string indexationFilter = !TextBoxIndexLookup.Text.Equals(string.Empty) ? $"indexation_id LIKE '%{TextBoxIndexLookup.Text}%'" : "";
            string usernameFilter = !TextBoxUsernameLookup.Text.Equals(string.Empty) ? $"username LIKE '%{TextBoxUsernameLookup.Text}%'" : "";
            string userUUIDFilter = !TextBoxUserUUIDLookup.Text.Equals(string.Empty) ? $"user_id LIKE '%{TextBoxUserUUIDLookup.Text}%'" : "";
            string notesFilter = !TextBoxNotesLookup.Text.Equals(string.Empty) ? $"notes LIKE '%{TextBoxNotesLookup.Text}%'" : "";
            string finalFilter = string.Empty;
            
            // If all the filters are empty, return all the entries
            if (indexationFilter == "" && userUUIDFilter == "" && notesFilter == "" && usernameFilter == "")
                return database.Select("Dirt");
            
            // Puts the filters together in a string ignoring any empty ones
            if (indexationFilter != "") finalFilter += indexationFilter;
            if (usernameFilter != "") finalFilter += finalFilter == "" ? usernameFilter : $" AND {usernameFilter}";
            if (userUUIDFilter != "") finalFilter += finalFilter == "" ? userUUIDFilter : $" AND {userUUIDFilter}";
            if (notesFilter != "") finalFilter += finalFilter == "" ? notesFilter : $" AND {notesFilter}";
            
            // Returns the filtered entries
            return database.Select("Dirt", finalFilter);
        }
        
        /// <summary>
        /// Add all the entries into the DataGridView
        /// </summary>
        public async Task ReloadEntriesAsync()
        { 
            // Clears the grid and the selection
            GridDirt.Rows.Clear();
            this.ForceClearSelections();
            
            // Get all the dirt entries existent in the database and initialise an array for the rows
            Mainframe.Instance.reloadEntriesToolStripMenuItem.Available = false;
            this.PictureLoading.Visible = true;
            List<string[]> dirtEntries = GetFilteredEntries();

            dirtEntries.Reverse();

            // Gets all of the rows to be added asynchronously and initialises the task list
            DataGridViewRow rowTemplate = (DataGridViewRow) GridDirt.RowTemplate.Clone();
            List<Task<DataGridViewRow>> taskList = new List<Task<DataGridViewRow>>();
            
            // Adds all the rows to the task list
            foreach (var entry in dirtEntries)
            {
                Task<DataGridViewRow> task = ProcessEntryAdditionAsync(entry, rowTemplate);
                taskList.Add(task);
            }

            // Awaits all the tasks and adds the rows to the DataGridView
            DataGridViewRow[] rows = await Task.WhenAll(taskList);

            // Adds the rows to the DataGridView and updates the label
            GridDirt.Rows.AddRange(rows);
            
            string entriesText = dirtEntries.Count == 1 ? "entry" : "entries";
            LabelEntriesDisplay.Text = $@"Now displaying {dirtEntries.Count} {entriesText}";
            Mainframe.Instance.reloadEntriesToolStripMenuItem.Available = true;
            this.PictureLoading.Visible = false;
        }

        /// <summary>
        /// Forcibly clears the selection of the DataGridView so that the state of the custom
        /// selection is as if the program had just started
        /// </summary>
        private void ForceClearSelections()
        {
            GridLoadingFlag = true;  // Tags the next selection change event as the first one

            // Resets the previously selected row to the default colour
            if (this.SelectedRow != null)
                this.SelectedRow.DefaultCellStyle.BackColor = Color.White;

            // Clears the selection and resets the selected row to null
            this.SelectedRow = null;
            GridDirt.ClearSelection();
        }

        /// <summary>
        /// Handles the asynchronous addition of content into the DataGridView
        /// </summary>
        /// <param name="entry">The entry information to add into the grid</param>
        /// <param name="rowTemplate">The template to add the row as</param>
        private async Task<DataGridViewRow> ProcessEntryAdditionAsync(string[] entry, DataGridViewRow rowTemplate)
        {
            return await Task.Run(async () =>
            {
                // Gets a newly connected manager for this async thread
                SQLDatabaseManager database = Program.CreateManagerFromCredentials(Program.DefaultHost, Program.DefaultCredentials);
                
                DiscordUser user = new DiscordUser(entry[1]);
                string informationString = user.GetInformationString(entry);
                rowTemplate = (DataGridViewRow) rowTemplate.Clone();

                // Gets the attachment ID from the indexation ID
                string dirtPath = await DirtManager.GetDirtPicture(entry[2]);

                // Creates a DataGridViewRow and add it to the gridContents array
                Image userAvatar = FileUtilExtensions.GetImageFromFileStream(await user.GetUserAvatar(ImageAccessor));
                Image dirtImage = FileUtilExtensions.GetImageFromFileStream(dirtPath);

                rowTemplate?.CreateCells(GridDirt, entry[0], entry[1], userAvatar, informationString, dirtImage);
                
                // Disposes of the database connection
                database.Connector.Disconnect();
                database.Connector.Dispose();
                
                return rowTemplate;
            });
        }
        
        /// <summary>
        /// Keeps clearing the selection on the DataGridView so that it never displays a blue selected colour on it.
        /// After that, change the foreground colour of the cell to a slightly darker one, and set the previously
        /// selected cell to the default colour.
        /// </summary>
        private bool GridLoadingFlag { get; set; } = true;
        
        private void GridDirt_SelectionChanged(object sender, EventArgs e)
        {
            // Ignores the first selection change event, as it is triggered when the grid is loading.
            if (GridLoadingFlag)
            {
                GridLoadingFlag = false;
                return;
            }
            
            // Resets the previous selected row to the default colour
            if (SelectedRow != null) SelectedRow.DefaultCellStyle.BackColor = Color.White;
            if (GridDirt.CurrentRow != null && this.SelectedRow != null) GridDirt.CurrentRow.DefaultCellStyle.BackColor = Color.Khaki;
            
            this.SelectedRow = GridDirt.CurrentRow;
            GridDirt.ClearSelection();
        }

        /// <summary>
        /// Copies the content inside any of the information column cells showing a "copied to clipboard" prompt
        /// followed by the reposition of the original content.
        /// </summary>
        private async void GridDirt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1) return;
            if (e.ColumnIndex == 4) await this.HandleImageToClipboard(e.RowIndex);
            if (e.ColumnIndex != 3) return;

            // Gets the clicked cell and the relevant contents
            DataGridViewCell cell = GridDirt.Rows[e.RowIndex].Cells[3];
            string originalContent = cell.Value.ToString();

            if (originalContent == "Copied to Clipboard") return;
            
            string userId = GridDirt.Rows[e.RowIndex].Cells[1].Value.ToString();
            string indexationId = GridDirt.Rows[e.RowIndex].Cells[0].Value.ToString();
            DiscordUser user = new DiscordUser(userId);
            SQLDatabaseManager database = Program.CreateManagerFromCredentials(Program.DefaultHost, Program.DefaultCredentials);
            
            // Gets the information formatted in the discord-pasteable format
            string information = user.GetInformationString(database, indexationId, true);
            Clipboard.SetData(DataFormats.Text, information);

            cell.Value = "Copied to Clipboard";
            await Task.Delay(1 * 1000);
            cell.Value = originalContent;
        }
        
        /// <summary>
        /// Handles the click on the 4th column of the DataGridView, which contains the dirt pictures.
        /// It copies the image to the clipboard and shows a "Copied" image for a second before reverting back.
        /// </summary>
        /// <param name="rowIndex">The index of the row that was clicked on</param>
        private async Task HandleImageToClipboard(int rowIndex)
        {
            // Gets the clicked cell and the relevant contents
            DataGridViewCell cell = GridDirt.Rows[rowIndex].Cells[4];
            Image originalContent = (Image) cell.Value;

            if (originalContent == Resources.copied) return;
            
            Clipboard.SetImage(originalContent);
            cell.Value = Resources.copied;
            await Task.Delay(1 * 1000);
            cell.Value = originalContent;
        }
        
        /// <summary>
        /// Highlights the row when the mouse enters it by changing the background colour to a light grey, unless
        /// it is the currently selected row, in which case it does nothing.
        /// </summary>
        private void GridDirt_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1) return;
            if (GridDirt.Rows[e.RowIndex] == SelectedRow) return;
            
            DataGridViewRow row = GridDirt.Rows[e.RowIndex];
            row.DefaultCellStyle.BackColor = Color.LightGray;
        }
        
        /// <summary>
        /// Returns the row to its original colour when the mouse leaves it, unless it is the currently selected row,
        /// in which case it does nothing.
        /// </summary>
        private void GridDirt_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1) return;
            if (GridDirt.Rows[e.RowIndex] == SelectedRow) return;
            
            DataGridViewRow row = GridDirt.Rows[e.RowIndex];
            row.DefaultCellStyle.BackColor = Color.White;
        }
        
        /// <summary>
        /// Displays an EntryViewingDialog with the selected entry's information
        /// </summary>
        private void ButtonViewEntry_Click(object sender, EventArgs e)
        {
            if (this.SelectedRow == null) return;
            
            // Gets the user and the entry data
            string indexationId = this.SelectedRow.Cells[0].Value.ToString();
            SQLDatabaseManager database = Program.CreateManagerFromCredentials(Program.DefaultHost, Program.DefaultCredentials);
            string[] entry = database.Select("Dirt", $"indexation_id = '{indexationId}'")[0];
            DiscordUser user = new DiscordUser(entry[1]);
            
            // Opens the viewing dialog
            EntryViewingDialog viewingDialog = new EntryViewingDialog(user, entry, this.DirtManager, this.ImageAccessor);
            viewingDialog.Show();
        }
        
        /// <summary>
        /// Reloads the grid with the filters, disabling the button and setting a "Loading" message on it until it
        /// the process is finished.
        /// </summary>
        private async void ButtonApplyFilters_Click(object sender, EventArgs e)
        {
            ButtonApplyFilters.Text = @"Loading...";
            ButtonApplyFilters.Enabled = false;
            await ReloadEntriesAsync();
            ButtonApplyFilters.Enabled = true;
            ButtonApplyFilters.Text = @"Apply Filters";
        }
    }
}