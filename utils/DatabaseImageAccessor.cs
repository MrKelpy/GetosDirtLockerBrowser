using System;
using System.Data.SqlClient;
using LaminariaCore_Databases.sqlserver;

namespace GetosDirtLockerBrowser.utils;

/// <summary>
/// This class is responsible for handling the two image tables in the database,
/// adding and deleting them.
/// </summary>
public class DatabaseImageAccessor
{
    
    /// <summary>
    /// Checks if an image exists in the database based on a specified table name and ID.
    /// </summary>
    /// <param name="id">The image ID to check for</param>
    /// <param name="table">The table to check for the existence in</param>
    /// <returns></returns>
    private bool ImageExists(string id, string table)
    {
        try
        {
            SQLDatabaseManager database = Program.CreateManagerFromCredentials(Program.DefaultHost, Program.DefaultCredentials);
            return database.Select(table, $"content_id = '{id}'").Count > 0;
        }
        
        // If an exception occurs, return false.
        catch (Exception e) { return false; }
    }
    
    /// <summary>
    /// Gets an image from the database based on a specified table name and ID.
    /// </summary>
    /// <param name="id">The ID to get the image from</param>
    /// <param name="table">The storate table holding the image</param>
    /// <returns>A byte[] with the image contents</returns>
    private byte[] GetImage(string id, string table)
    {
        try
        {
            // Create the command and add the parameters.
            SQLDatabaseManager database = Program.CreateManagerFromCredentials(Program.DefaultHost, Program.DefaultCredentials);
            using SqlCommand command = new($"SELECT * FROM {table} WHERE content_id = @id", database.Connector.Connection);
            command.Parameters.AddWithValue("@id", id);
            
            // Execute the command and return the result.
            SqlDataReader reader = command.ExecuteReader();
            return reader.Read() ? (byte[])reader["content"] : null;
        }
        
        // If an exception occurs, return null.
        catch (Exception e) { return null; }
    }
    
    /// <summary>
    /// Shortcut method to check if a dirt image exists in the database.
    /// </summary>
    /// <param name="id">The ID to check for in the database</param>
    /// <returns>Whether or not the image exists</returns>
    public bool DirtImageExists(string id) => this.ImageExists(id, "AttachmentStorage");
    
    /// <summary>
    /// Shortcut method to check if an avatar image exists in the database.
    /// </summary>
    /// <param name="id">The ID to check for in the database</param>
    /// <returns>Whether or not the image exists</returns>
    public bool AvatarImageExists(string id) => this.ImageExists(id, "AvatarStorage");
    
    /// <summary>
    /// Shortcut method to get a dirt image from the database.
    /// </summary>
    /// <param name="id">The ID to check for in the database</param>
    /// <returns>A byte[] containing the image data</returns>
    public byte[] GetDirtImage(string id) => this.GetImage(id, "AttachmentStorage");
    
    /// <summary>
    /// Shortcut method to get an avatar image from the database.
    /// </summary>
    /// <param name="id">The ID to check for in the database</param>
    /// <returns>A byte[] containing the image data</returns>
    public byte[] GetAvatarImage(string id) => this.GetImage(id, "AvatarStorage");
}