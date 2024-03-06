using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using LaminariaCore_Databases.sqlserver;
using LaminariaCore_General.common;

namespace GetosDirtLocker.utils;

/// <summary>
/// This class is responsible for managing the dirt picture storage and downloads, aswell as caching.
/// </summary>
public class DirtStorageManager
{

    /// <summary>
    /// The section of the file manager used to store the dirt pictures.
    /// </summary>
    private Section DirtStorageSection { get; } = Program.FileManager.AddSection("dirt");
    
    /// <summary>
    /// The database manager used to access and interact with the db
    /// </summary>
    public SQLDatabaseManager Database { get; }
    
    /// <summary>
    /// General constructor of the class, set the database manager.
    /// </summary>
    /// <param name="manager">The database manager used throughout the program</param>
    public DirtStorageManager(SQLDatabaseManager manager) => this.Database = manager;
    
    /// <summary>
    /// Downloads the dirt picture from the given URL and stores it in the dirt storage section under a name equal
    /// to the attachment ID.
    /// </summary>
    /// <param name="url">The URL to download the picture from</param>
    /// <param name="id">The ID to </param>
    public async Task<bool> DownloadDirtPicture(string url, string id)
    {
        // Create the file path and download the avatar.
        string filepath = this.DirtStorageSection.SectionFullPath + $"/{id}.png";
        using WebResponse response = await WebRequest.Create(url).GetResponseAsync();
        
        // Copy the response stream to the file stream.
        using Stream responseStream = response.GetResponseStream();
        if (responseStream == null) return false;

        using FileStream fileStream = new(filepath, FileMode.Create);
        await responseStream.CopyToAsync(fileStream);

        return true;
    }
    
    /// <summary>
    /// Tries to check if the URL is a downloadable picture.
    /// </summary>
    /// <param name="url">The URL to check</param>
    /// <returns>Whether or not the URL is downloadable</returns>
    public static async Task<bool> UrlIsDownloadablePicture(string url)
    {
        try
        {
            using WebResponse response = await WebRequest.Create(url).GetResponseAsync();
            return response.ContentType.Contains("image");
        }
        catch (WebException) { return false; }
    }
    
    /// <summary>
    /// Gets the path to the dirt picture, if it exists. If it doesn't, return null.
    /// </summary>
    /// <param name="id">The ID of the picture to search for</param>
    /// <returns>The filepath for the picture</returns>
    public string GetDirtPicturePath(string id)
    {
        string filepath = this.DirtStorageSection.SectionFullPath + $"/{id}.png";
        return File.Exists(filepath) ? filepath : null;
    }

    /// <summary>
    /// Tries to check if the dirt picture exists in the storage, if not, accesses the database and gets
    /// the URL for the attachment, and downloads it.
    /// </summary>
    /// <param name="id">The ID of the picture to download</param>
    /// <returns>The filepath to the picture</returns>
    public async Task<string> GetDirtPicture(string id)
    {
        // If the picture return the path to it.
        if (this.GetDirtPicturePath(id) is { } path) return path;
        
        // If the picture doesn't exist, get the URL from the database and download it.
        List<string[]> results = this.Database.Select("Attachment", $"attachment_id = '{id}'");
        if (results.Count == 0) return null;
        
        return await this.DownloadDirtPicture(results[0][2], id) ? this.GetDirtPicturePath(id) : null;
    }
    
}