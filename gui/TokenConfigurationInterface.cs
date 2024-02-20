using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using GetosDirtLocker.requests;
using GetosDirtLocker.utils;
using LaminariaCore_General.common;
using LaminariaCore_General.utils;

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
        public static TokenConfigurationInterface Instance { get; } = new ();
        
        /// <summary>
        /// General constructor of the class.
        /// </summary>
        public TokenConfigurationInterface()
        {
            InitializeComponent();
        }

        /// <returns>
        /// Prepares the form and returns the frame, containing all the elements.
        /// </returns>
        public Panel GetLayout() => this.Frame;

        /// <summary>
        /// Returns the token stored in the text box.
        /// </summary>
        public byte[] GetToken()
        {
            byte[] muid = Encoding.UTF8.GetBytes(GetUniqueMachineID()); // Gets the unique machine ID.
            
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(TextBoxToken.Text), muid,
                DataProtectionScope.LocalMachine);
        }
        
        /// <summary>
        /// Tries to decode the token and returns it as a string.
        /// </summary>
        /// <param name="token">The token byte[] to decode</param>
        /// <returns>A string representation of the token</returns>
        public static string DecodeToken(byte[] token)
        {
            byte[] muid = Encoding.UTF8.GetBytes(GetUniqueMachineID()); // Gets the unique machine ID.
            
            return Encoding.UTF8.GetString(ProtectedData.Unprotect(token, muid, DataProtectionScope.LocalMachine));
        }

        /// <summary>
        /// Looks into the hardware of the machine for machine-specific information, hashes it and returns
        /// it to be used as a unique machine ID for encryption and decryption.
        /// </summary>
        public static string GetUniqueMachineID()
        {
            string hardwareInfo = string.Empty;

            // Create a searcher for the motherboard and processor.
            ManagementObjectSearcher boardSearcher = new ("SELECT * FROM Win32_BaseBoard");
            ManagementObjectSearcher processorSearcher = new ("SELECT * FROM Win32_Processor");
            
            // Get the hardware information from the motherboard, adding the manufacturer and product to the string.
            foreach (var board in boardSearcher.Get())
                hardwareInfo += board["Manufacturer"].ToString() + board["Product"];

            // Get the hardware information from the processor, adding the manufacturer and processor ID to the string.
            foreach (var processor in processorSearcher.Get())
                hardwareInfo += processor["Manufacturer"].ToString() + processor["ProcessorId"];

            return Encoding.UTF8.GetString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(hardwareInfo)));
        }
    }
}