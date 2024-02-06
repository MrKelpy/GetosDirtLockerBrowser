using System.Windows.Forms;
using GetosDirtLocker.requests;

namespace GetosDirtLocker.gui
{
    /// <summary>
    /// This interface is used to configure the token used to access the Discord API.
    /// </summary>
    public partial class TokenConfigurationInterface : Form
    {
        
        /// <summary>
        /// The singleton instance of the class, used to access the form.
        /// </summary>
        public static TokenConfigurationInterface Instance { get; } = new TokenConfigurationInterface();
        
        /// <summary>
        /// General constructor of the class.
        /// </summary>
        public TokenConfigurationInterface()
        {
            InitializeComponent();
        }
        
        /// <returns>
        /// Returns the frame of the form, containing all the elements.
        /// </returns>
        public Panel GetLayout() => this.Frame;
        
        /// <summary>
        /// Returns the token stored in the text box.
        /// </summary>
        public string GetToken() => this.TextBoxToken.Text;
    }
}