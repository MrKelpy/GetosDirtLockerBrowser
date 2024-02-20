using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GetosDirtLocker.gui
{
    /// <summary>
    /// The main interface for adding new dirt into the locker. Also displays the last few entries.
    /// </summary>
    public partial class LockerAdditionInterface : Form
    {
        
        /// <summary>
        /// The singleton instance of the class, used to access the form.
        /// </summary>
        public static LockerAdditionInterface Instance { get; } = new LockerAdditionInterface();
        
        /// <summary>
        /// Main constructor of the class
        /// </summary>
        private LockerAdditionInterface()
        {
            InitializeComponent();
            ljihgvfyc.Focus();

            PictureLoading.SizeMode = PictureBoxSizeMode.Zoom;
        }

        /// <returns>
        /// Returns the frame of the form, containing all the elements.
        /// </returns>
        public Panel GetLayout() => this.Frame;
    }
}