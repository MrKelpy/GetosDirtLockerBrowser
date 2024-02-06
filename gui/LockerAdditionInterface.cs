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
            label1.Focus();
        }

        /// <summary>
        /// Changes the state of all the controls in the form to the specified state.
        /// </summary>
        /// <param name="state">The state to update the controls to</param>
        public void ChangeControlStates(bool state)
        {
            foreach (Control control in this.Frame.Controls.OfType<Control>())
                control.Enabled = state;
        }

        /// <returns>
        /// Returns the frame of the form, containing all the elements.
        /// </returns>
        public Panel GetLayout() => this.Frame;
    }
}