using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using GetosDirtLocker.gui;
using GetosDirtLocker.Properties;
using GetosDirtLocker.utils;
using LaminariaCore_Databases.sqlserver;
using LaminariaCore_General.common;
using Microsoft.SqlServer.Management.HadrData;

namespace GetosDirtLocker
{
    static class Program
    {
        
        /// <summary>
        /// The file management system used to manage the files of the application.
        /// </summary>
        public static FileManager FileManager { get; } = new (".GetosLocker", true);

        /// <summary>
        /// The loader image used to display the loading process.
        /// </summary>
        public static Image LoaderImage { get; } = Resources.loader;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Checks if the database exists, and if it doesn't, creates it.
            SQLServerConnector connector = new SQLServerConnector(@".\SQLEXPRESS", "master");
            SQLDatabaseManager manager = new SQLDatabaseManager(connector);
            
            if (!manager.DatabaseExists("DirtLocker"))
                manager.RunSqlScript("./sql/dirtlocker.sql");

            manager.UseDatabase("DirtLocker");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Mainframe(manager));
        }
    }
}