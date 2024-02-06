using System.Windows.Forms;

namespace GetosDirtLocker.gui
{
    /// <summary>
    /// The interface used to look up dirt in the locker.
    /// </summary>
    public partial class DirtLookupInterface : Form
    {
        
        /// <summary>
        /// The singleton instance of the class, used to access the form.
        /// </summary>
        public static DirtLookupInterface Instance { get; } = new DirtLookupInterface();
        
        /// <summary>
        /// The main constructor of the class.
        /// </summary>
        private DirtLookupInterface()
        {
            InitializeComponent();
        }
        
        /// <returns>
        /// Returns the frame of the form, containing all the elements.
        /// </returns>
        public Panel GetLayout() => this.Frame;
    }
}