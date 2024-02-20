using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetosDirtLocker.gui;
using LaminariaCore_General.common;

namespace GetosDirtLocker
{
    static class Program
    {
        
        /// <summary>
        /// The file management system used to manage the files of the application.
        /// </summary>
        public static FileManager FileManager { get; } = new (".GetosLocker", true);
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Mainframe());
        }
    }
}