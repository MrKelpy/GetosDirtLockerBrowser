using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using GetosDirtLocker.requests;
using LaminariaCore_Databases.sqlserver;
using LaminariaCore_General.common;

namespace GetosDirtLocker.utils;

/// <summary>
/// This class represents a discord user and implements many useful methods to access the discord API and retrieve
/// resources and information about them.
/// </summary>
public class DiscordUser
{
    /// <summary>
    /// The discord user's UUID.
    /// </summary>
    public ulong Uuid { get; }
    
    /// <summary>
    /// Stores the user's token and checks if it is assigned to a user.
    /// </summary>
    /// <param name="uuid">The uuid of the user to get the information for</param>
    public DiscordUser(string uuid)
    {
        if (uuid.Length > 0)
            this.Uuid = ulong.Parse(uuid);
    }

    /// <summary>
    /// Gets the user object by their discord ID
    /// </summary>
    /// <returns>An IUser object containing the user ID, or null if it doesn't exist</returns>
    public async Task<IUser> GetUserFromID()
    {
        if (this.Uuid == default) return null;
        return await DiscordInteractions.Client.GetUserAsync(this.Uuid);
    }

    /// <summary>
    /// Checks if the account exists and is valid.
    /// </summary>
    /// <returns>Whether or not the account exists</returns>
    public async Task<bool> CheckAccountExistence() => await this.GetUserFromID() != null;

    /// <summary>
    /// Gets the information string to be displayed in the locker.
    /// </summary>
    /// <param name="entry">The entry string[] with all the information about a given dirt</param>
    /// <param name="discord">Whether to format the text with discord's characters or not</param>
    /// <returns></returns>
    public string GetInformationString(string[] entry, bool discord = false)
    {
        string message = string.Empty;  // The message to return
        string nl = Environment.NewLine;
        
        if (discord) message += $"**User Mention**: <@{this.Uuid}>{nl}";  // Add the user mention if its discord-formatted
        message += discord ? $"**UUID**: `{this.Uuid}`{nl}" : $"UUID: {this.Uuid}{nl}";  // Adds the uuid
        
        // Gets the username and adds it to the message
        string username = entry[3];
        message += discord ? $"**Username**: `{username}`{nl}" : $"Username: {username}{nl}";
        
        // Adds the indexation ID to the message
        message += discord ? $"**Indexation ID**: `{entry[0]}`{nl}" : $"Indexation ID: {entry[0]}{nl}";
        
        // Adds the additional information to the message
        if (entry[0] == string.Empty) return message;
        message += discord ? $"{nl}**Additional Notes**: `{entry[4]}`" : $"{nl}Additional Notes: {entry[4]}";

        return message;
        
    }

    /// <summary>
    /// Gets the information string to be displayed in the locker.
    /// </summary>
    /// <param name="database">The database manager used to access the database and query the information</param>
    /// <param name="indexationID">The indexation ID to include in the string</param>
    /// <param name="discord">Whether to format the text with discord's characters or not</param>
    /// <returns>A string containing info about the user</returns>
    public string GetInformationString(SQLDatabaseManager database, string indexationID, bool discord = false)
    {
        string[] dirtEntry = database.Select("Dirt", $"indexation_id = '{indexationID}'")[0];
        return this.GetInformationString(dirtEntry, discord);
    }

    /// <summary>
    /// Gets the path to the user's avatar, downloading it from the discord API and storing it in the cache.
    /// </summary>
    /// <param name="accessor">The Database Image Accessor used to get, add and manage the images on the database storage tables</param>
    /// <returns>The avatar url of the account bound to this object</returns>
    public async Task<string> GetUserAvatar(DatabaseImageAccessor accessor)
    {
        Section avatarsSection = Program.FileManager.AddSection("avatars");
        string expectedPath = avatarsSection.SectionFullPath + $"/{this.Uuid}.png";
        
        // If the avatar is already downloaded, return the path to the file.
        if (File.Exists(expectedPath)) return expectedPath;
        
        // If the avatar isn't present in the filesystem, check if it is in the database.
        if (accessor.AvatarImageExists(this.Uuid.ToString()))
        {
            using FileStream fileStream = new(expectedPath, FileMode.OpenOrCreate);
            byte[] image = accessor.GetAvatarImage(this.Uuid.ToString());
            await fileStream.WriteAsync(image, 0, image.Length);
            return expectedPath;
        }
        
        return await this.DownloadUserAvatar(accessor);
    }
    
    /// <summary>
    /// Downloads the user's avatar and returns the path to the file.
    /// </summary>
    /// <param name="accessor">The Database Image Accessor used to get, add and manage the images on the database storage tables</param>
    /// <returns>The path to the just-downloaded file</returns>
    public async Task<string> DownloadUserAvatar(DatabaseImageAccessor accessor)
    {
        Section avatarsSection = Program.FileManager.AddSection("avatars");
        IUser user = await this.GetUserFromID();
        
        // Create the file path and download the avatar.
        string filepath = avatarsSection.SectionFullPath + $"/{this.Uuid}.png";
        using WebResponse response = await WebRequest.Create(user.GetAvatarUrl()).GetResponseAsync();
        
        // Copy the response stream to the file stream.
        using Stream responseStream = response.GetResponseStream();
        if (responseStream == null) return null;

        // Try to copy the stream to the file, and if it fails, return null.
        try
        {
            using FileStream fileStream = new (filepath, FileMode.Create);
            await responseStream.CopyToAsync(fileStream);
        }
        catch (IOException e) { return null; }
        catch (TimeoutException e) { return null; }

        await accessor.AddAvatarImageToDatabase(this.Uuid.ToString(), filepath);
        return filepath;
    }

    /// <summary>
    /// Tries to get the user's nickname in the Adocord server. If the bot isn't in the server, it returns null.
    /// </summary>
    /// <returns>The username of the user or an empty string if it can't get it</returns>
    public string TryGetAdocordUsername()
    {
        SocketGuild adocord = DiscordInteractions.Client.GetGuild(865372252433940500);
        if (adocord == null) return string.Empty;
        
        IGuildUser user = adocord.GetUser(this.Uuid);
        return user?.Nickname ?? user?.Username;
    }
    
    /// <summary>
    /// Gets the next indexation ID for the user.
    /// </summary>
    /// <param name="database">The database manager to get the user information from</param>
    /// <returns>The indexation ID formatted as #USER-COUNT.TOTAL-COUNT.DDMMYY</returns>
    public string GetNextIndexationID(SQLDatabaseManager database)
    {
        string userDirtCount = database.Select(new [] {"user_total"}, "DiscordUser", $"user_id = '{this.Uuid}'")[0][0];
        userDirtCount = (int.Parse(userDirtCount) + 1).ToString();
        
        string totalDirtCount = (database.Select("Dirt").Count + 1).ToString();
        string formattedDate = DateTime.Now.ToString("ddMMyy");
        
        // Add trailing zeroes to the counts
        userDirtCount = userDirtCount.Length <= 1 ? $"0{userDirtCount}" : userDirtCount;
        totalDirtCount = totalDirtCount.Length <= 1 ? $"0{totalDirtCount}" : totalDirtCount;
        
        return $"#{userDirtCount}.{totalDirtCount}.{formattedDate}";
    }
    
    /// <summary>
    /// Adds the user to the database if it doesn't exist.
    /// </summary>
    /// <param name="database">The database manager to add the user with</param>
    public void AddToDatabase(SQLDatabaseManager database)
    {
        if (database.Select("DiscordUser", $"user_id = '{this.Uuid}'").Count > 0) return;
        database.InsertInto("DiscordUser", this.Uuid.ToString(), "0");
    }

    /// <summary>
    /// Increments the total dirt count of the user in the database.
    /// </summary>
    /// <param name="database">The database manager to add the user with</param>
    public void IncrementTotalDirtCount(SQLDatabaseManager database)
    {
        string userDirtCount = database.Select(new [] {"user_total"}, "DiscordUser", $"user_id = '{this.Uuid}'")[0][0];
        database.Update("DiscordUser", $"user_total", int.Parse(userDirtCount)+1);
    }
}