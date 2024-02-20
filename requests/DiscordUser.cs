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
    private int Uuid { get; set; }
    
    /// <summary>
    /// Stores the user's token and checks if it is assigned to a user.
    /// </summary>
    /// <param name="uuid">The uuid of the user to get the information for</param>
    public DiscordUser(int uuid)
    {
        this.Uuid = uuid;
    }

    /// <summary>
    /// Checks if the account exists and is valid.
    /// </summary>
    private void CheckAccountExistence()
    {
        
        
    }
    
    
}