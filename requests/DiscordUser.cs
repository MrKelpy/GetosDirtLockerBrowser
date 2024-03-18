﻿using System;
using System.IO;
using System.Threading.Tasks;
using GetosDirtLockerBrowser.utils;
using LaminariaCore_Databases.sqlserver;
using LaminariaCore_General.common;

namespace GetosDirtLockerBrowser.requests;

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

        return null;
    }
}