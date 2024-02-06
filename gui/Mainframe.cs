using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetosDirtLocker.requests;
using LaminariaCore_Winforms.forms.extensions;

namespace GetosDirtLocker.gui
{
    /// <summary>
    /// The mainframe of the application, working in conjunction with the mainframe system in
    /// LaminariaCore-Winforms to provide a single-window GUI for the application.
    /// </summary>
    public partial class Mainframe : Form
    {
        
        /// <summary>
        /// Whether or not the token should be refreshed. This should be set to true once we switch
        /// to the token configuration interface, and set to false once we refresh it.
        /// </summary>
        public static bool TokenRefresh { get; set; } = true;
        
        /// <summary>
        /// The mainframe of the application, working in conjunction with the mainframe system in
        /// the LaminariaCore-Winforms library to provide a single-window GUI for the application.
        /// </summary>
        public Mainframe()
        {
            InitializeComponent();
            MainLayout.SetAllFrom(TokenConfigurationInterface.Instance.GetLayout());
            this.Text = TokenConfigurationInterface.Instance.Text;
            CenterToScreen();
        }
        
        /// <summary>
        /// Refreshes the token if the token refresh flag is set, changing the enabled
        /// state of the locker addition controls accordingly.
        /// </summary>
        private async Task RefreshToken()
        {
            if (!TokenRefresh) return;  // No need to refresh the token if we the flag is not set.
            
            // If the token is invalid, then we disable the locker addition controls.
            if (!await DiscordInteractions.IsTokenValid(TokenConfigurationInterface.Instance.GetToken()))
            {
                LockerAdditionInterface.Instance.ChangeControlStates(false);
                return;
            }
            
            // Otherwise, we enable them.
            TokenRefresh = false;
            LockerAdditionInterface.Instance.ChangeControlStates(true);
        }

        /// <summary>
        /// Switches the displayed interface to the new entry interface.
        /// </summary>
        private async void ToolStripNewEntry_Click(object sender, EventArgs e)
        {
            await RefreshToken();
            TokenRefresh = false;
            
            this.MainLayout.SetAllFrom(LockerAdditionInterface.Instance.GetLayout());
        }

        /// <summary>
        /// Switches the displayed interface to the dirt lookup interface. If the token refresh flag
        /// is set, then the token is refreshed.
        /// </summary>
        private async void ToolStripDirtLookup_Click(object sender, EventArgs e)
        {
            await RefreshToken();
            TokenRefresh = false;
            
            this.MainLayout.SetAllFrom(DirtLookupInterface.Instance.GetLayout());
        }

        /// <summary>
        /// Switches the displayed interface to the token configuration interface, setting the
        /// token refresh flag to true.
        /// </summary>
        private void ToolStripTokenConfig_Click(object sender, EventArgs e)
        {
            TokenRefresh = true;
            this.MainLayout.SetAllFrom(TokenConfigurationInterface.Instance.GetLayout());
        }
    }
}