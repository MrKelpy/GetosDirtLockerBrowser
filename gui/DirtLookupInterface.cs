using System.Windows.Forms;
using LaminariaCore_Databases.sqlserver;

namespace GetosDirtLocker.gui
{
    /// <summary>
    /// The interface used to look up dirt in the locker.
    /// </summary>
    public partial class DirtLookupInterface : Form
    {
        
        /// <summary>
        /// The main constructor of the class.
        /// </summary>
        public DirtLookupInterface(SQLDatabaseManager manager)
        {
            InitializeComponent();
        }
        
        /// <returns>
        /// Returns the frame of the form, containing all the elements.
        /// </returns>
        public Panel GetLayout() => this.Frame;
    }
}