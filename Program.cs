using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetosDirtLocker.gui;
using GetosDirtLocker.Properties;
using GetosDirtLocker.utils;
using LaminariaCore_Databases.sqlserver;
using LaminariaCore_General.common;
using LaminariaCore_General.utils;
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
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Checks if the database exists, and if it doesn't, creates it.
            Section dataSection = FileManager.AddSection("data");
            string filepath = dataSection.AddDocument("database.cfg");

            // Gets the database host from the file, if it doesn't exist, uses the default one.
            string[] databaseHostFile = FileUtils.ReadFromFile(filepath).Count > 0
                ? FileUtils.ReadFromFile(filepath)[0].Trim().Split(':')
                : Array.Empty<string>();
            
            string host = databaseHostFile.Length <= 0 ? @".\SQLEXPRESS" : $@"{databaseHostFile[0]},{databaseHostFile[1]}";

            try
            {
                SQLServerConnector connector;
                
                // If the host is not the default one, manually specify the connection string to use TCP/IP.
                if (!host.Equals(@".\SQLEXPRESS"))
                    connector = new SQLServerConnector(host, "master", databaseHostFile[2], databaseHostFile[3]);
                
                // Otherwise, use the automatic constructor to build the connection string.
                else connector = new SQLServerConnector(host, "master");
                
                SQLDatabaseManager manager = new SQLDatabaseManager(connector);

                if (manager.DatabaseExists("DirtLocker"))
                    manager.RunSqlScript("./sql/dirtlocker.sql");

                manager.UseDatabase("DirtLocker");
                new Thread(EnsureNetworkThread).Start();
                    
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Mainframe(manager));
            }
            catch (SqlException e)
            {
                MessageBox.Show($"An error occurred while trying to connect to the database on {host}. Please check the database host and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ensures that there's always a network connection present, and stops the program
        /// if there isn't.
        /// </summary>
        public static void EnsureNetworkThread()
        {
            while (true)
            {
                if (!NetworkUtils.IsWifiConnected())
                {
                    Mainframe.Instance.Close();
                    MessageBox.Show($@"Lost connection to the internet. {Environment.NewLine}Please connect to a network and try again.", @"Geto's Dirt Locker - Network Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Environment.Exit(0);
                }
                
                Thread.Sleep(1*1000);  // Sleep for 1 second.
            }
        }
    }
}