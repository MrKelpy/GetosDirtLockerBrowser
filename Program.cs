using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using GetosDirtLockerBrowser.gui;
using LaminariaCore_Databases.sqlserver;
using LaminariaCore_General.common;
using LaminariaCore_General.utils;

namespace GetosDirtLockerBrowser
{
    static class Program
    {

        /// <summary>
        /// The file management system used to manage the files of the application.
        /// </summary>
        public static FileManager FileManager { get; } = new(".GetosLocker", true);

        /// <summary>
        /// The default credentials to use when connecting to the database, loaded from the configuration file.
        /// </summary>
        public static string[] DefaultCredentials { get; set; }


        /// <summary>
        /// The default host to use when connecting to the database, loaded from the configuration file.
        /// </summary>
        public static string DefaultHost { get; set; }

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

            DefaultHost = databaseHostFile.Length <= 0
                ? @".\SQLEXPRESS"
                : $@"{databaseHostFile[0]},{databaseHostFile[1]}";

            try
            {
                DefaultCredentials = new string[2];

                // If the host is not the default one, manually specify the connection string to use TCP/IP.
                if (!DefaultHost.Equals(@".\SQLEXPRESS"))
                {
                    DefaultCredentials[0] = databaseHostFile[2];
                    DefaultCredentials[1] = databaseHostFile[3];
                }

                // Create a database manager from the credentials provided.
                SQLDatabaseManager manager = CreateManagerFromCredentials(DefaultHost, DefaultCredentials);

                // Use the database and start the network thread, checking for network connection.
                new Thread(EnsureNetworkThread).Start();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new Mainframe(manager));
            }

            // If an SQL exception occurs, show an error message letting the user know that the database couldn't be accessed.
            catch (SqlException)
            {
                MessageBox.Show(
                    $"An error occurred while trying to connect to the database on {DefaultHost}. Please check the database host and try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Creates a database manager from the credentials provided, can either be a windows authentication or a user authentication.
        /// </summary>
        /// <param name="host">The host of the SQL Server</param>
        /// <param name="credentials">The credentials provided in the configuration file</param>
        /// <returns>The SQL Database Manager used to access the application</returns>
        public static SQLDatabaseManager CreateManagerFromCredentials(string host, string[] credentials)
        {

            // If the credentials are present, use an sql authentication
            if (credentials.Any(x => x != null))
            {
                SQLServerConnector connector = new SQLServerConnector(host, "DirtLocker", credentials[0], credentials[1]);
                return new SQLDatabaseManager(connector);
            }

            // If the credentials are not present, use a windows authentication
            else
            {
                SQLServerConnector connector = new SQLServerConnector(host, "DirtLocker");
                return new SQLDatabaseManager(connector);
            }

        }

        /// <summary>
        /// Checks if the network is connected, with 5 attempts of tolerance.
        /// </summary>
        /// <param name="tries">The amount of tries to attempt before exiting</param>
        static bool CheckConnection(int tries = 0)
        {
            // Pings google to check if the network is connected.
            bool isConnected = NetworkUtils.IsWifiConnected();

            if (!isConnected && tries >= 5) return false;

            if (!isConnected) return CheckConnection(++tries);
            return true;
        }

        /// <summary>
        /// Ensures that there's always a network connection present, and stops the program
        /// if there isn't.
        /// </summary>
        static void EnsureNetworkThread()
        {
            while (true)
            {
                if (CheckConnection()) continue;

                // If the network isn't connected, show an error message and close the application.
                Mainframe.Instance.Invoke(new MethodInvoker(() => Mainframe.Instance.Close()));
                MessageBox.Show($@"Lost connection to the internet. {Environment.NewLine}Please connect to a network and try again.", @"Geto's Dirt Locker - Network Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
                return;
            }
        }
    }
}