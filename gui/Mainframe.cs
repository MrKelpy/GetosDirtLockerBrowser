using System;
using System.Linq;
using System.Windows.Forms;
using LaminariaCore_Databases.sqlserver;
using LaminariaCore_Winforms.forms.extensions;

namespace GetosDirtLockerBrowser.gui
{
    /// <summary>
    /// The mainframe of the application, working in conjunction with the mainframe system in
    /// LaminariaCore-Winforms to provide a single-window GUI for the application.
    /// </summary>
    public partial class Mainframe : Form
    {

        /// <summary>
        /// The singleton instance of the class, used to access the form.
        /// </summary>
        public static Mainframe Instance { get; private set; }
        
        /// <summary>
        /// The locker addition interface used to add new dirt into the locker.
        /// </summary>
        public static LockerInterface LockerAddition { get; set; }

        /// <summary>
        /// The mainframe of the application, working in conjunction with the mainframe system in
        /// the LaminariaCore-Winforms library to provide a single-window GUI for the application.
        /// </summary>
        public Mainframe()
        {
            InitializeComponent();
            CenterToScreen();
            
            // Sets the three interfaces into the properties defined above.
            LockerAddition = new LockerInterface();
            
            // Set the locker addition interface as the default interface.
            MainLayout.SetAllFrom(LockerAddition.GetLayout());
            this.Text = LockerAddition.Text;
            
            Instance = this;
        }

        /// <summary>
        /// Loads the mainframe, setting up any necessary configurations and settings needed.
        /// </summary>
        private async void Mainframe_Load(object sender, EventArgs e)
        {
            MainLayout.Focus();
            await LockerAddition.ReloadEntriesAsync();
        }
        
        /// <summary>
        /// Changes the enabled state of the locker addition controls.
        /// </summary>
        /// <param name="state">The boolean state to set them to</param>
        public void ChangeControlStates(bool state)
        {
            this.Invoke(() =>
            {
                foreach (Control control in MainLayout.Controls.OfType<Control>())
                {
                    if (control.GetType() == typeof(PictureBox)) continue;
                    control.Enabled = state;
                }
            });
        }

        /// <summary>
        /// Reload all entries in both the locker addition interface and the lookup interface.
        /// </summary>
        private async void reloadEntriesToolStripMenuItem_Click(object sender, EventArgs e) => await LockerAddition.ReloadEntriesAsync();
    }
}