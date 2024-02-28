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
    /// <param name="indexationID">The indexation ID to include in the string</param>
    /// <param name="discord">Whether to format the text with discord's characters or not</param>
    /// <param name="database">The database manager used to access the database and query the information</param>
    /// <returns>A string containing info about the user</returns>
    public string GetInformationString(SQLDatabaseManager database, string indexationID = "", bool discord = false)
    {
        string message = string.Empty;  // The message to return
        string nl = Environment.NewLine;
        string[] dirtEntry = database.Select("Dirt", $"indexation_id = '{indexationID}'")[0];
        
        if (discord) message += $"**User Mention**: <@{this.Uuid}>{nl}";  // Add the user mention if its discord-formatted
        message += discord ? $"**UUID**: `{this.Uuid}`{nl}" : $"UUID: {this.Uuid}{nl}";  // Adds the uuid
        
        // Gets the username and adds it to the message
        string username = dirtEntry[3];
        message += discord ? $"**Username**: `{username}`{nl}" : $"Username: {username}{nl}";
        
        // Adds the indexation ID to the message
        message += discord ? $"**Indexation ID**: `{indexationID}`{nl}" : $"Indexation ID: {indexationID}{nl}";
        
        // Adds the additional information to the message
        if (indexationID == string.Empty) return message;
        message += discord ? $"{nl}**Additional Notes**: `{dirtEntry[4]}`" : $"{nl}Additional Notes: {dirtEntry[4]}";

        return message;
    }

    /// <summary>
    /// Gets the path to the user's avatar, downloading it from the discord API and storing it in the cache.
    /// </summary>
    /// <returns>The avatar url of the account bound to this object</returns>
    public async Task<string> GetUserAvatar()
    {
        // If the user doesn't exist, return null.
        if (await this.GetUserFromID() is not { } user) return null;
        Section avatarsSection = Program.FileManager.AddSection("avatars");
        
        // If the avatar is already downloaded, return the path to the file.
        if (File.Exists(avatarsSection.SectionFullPath + $"/{this.Uuid}.png"))
            return avatarsSection.SectionFullPath + $"/{this.Uuid}.png";
        
        return await this.DownloadUserAvatar();
    }
    
    /// <summary>
    /// Downloads the user's avatar and returns the path to the file.
    /// </summary>
    /// <returns>The path to the just-downloaded file</returns>
    public async Task<string> DownloadUserAvatar()
    {
        Section avatarsSection = Program.FileManager.AddSection("avatars");
        IUser user = await this.GetUserFromID();
        
        // Create the file path and download the avatar.
        string filepath = avatarsSection.SectionFullPath + $"/{this.Uuid}.png";
        using WebResponse response = await WebRequest.Create(user.GetAvatarUrl()).GetResponseAsync();
        
        // Copy the response stream to the file stream.
        using Stream responseStream = response.GetResponseStream();
        if (responseStream == null) return null;
        
        using FileStream fileStream = new(filepath, FileMode.Create);
        await responseStream.CopyToAsync(fileStream);
        
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
        int totalDirtCount = database.Select("Dirt").Count;
        int formattedDate = int.Parse(DateTime.Now.ToString("ddMMyy"));
        
        return $"#{int.Parse(userDirtCount)+1}.{totalDirtCount+1}.{formattedDate}";
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