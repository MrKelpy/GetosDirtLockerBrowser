using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using Discord.WebSocket;
using GetosDirtLocker.gui;
using Image = System.Drawing.Image;

namespace GetosDirtLocker.requests
{
    /// <summary>
    /// This is a kind of rough API Wrapper for the Discord API using user tokens.
    /// </summary>
    public static class DiscordInteractions
    {
        
        /// <summary>
        /// The discord client that is used to interact with the API. Updated with IsTokenValid.
        /// </summary>
        public static DiscordSocketClient Client { get; set; }
        
        /// <summary>
        /// Tries to retrieve the user information through their token, returning a boolean for success.
        /// </summary>
        /// <param name="token">The encrypted token to check.</param>
        public static async Task<bool> IsTokenValid(byte[] token)
        {
            try
            {
                // Decode the token from the encrypted byte array.
                string tokenString = TokenConfigurationInterface.DecodeToken(token);
                TokenUtils.ValidateToken(TokenType.Bearer, tokenString);

                // Create a new client and log in with the token as a 'bot'
                DiscordInteractions.Client = new DiscordSocketClient();
                DiscordInteractions.Client.Log += Log;

                await DiscordInteractions.Client.LoginAsync(TokenType.Bot, tokenString, false);
                await DiscordInteractions.Client.StartAsync();
            }
            catch (ArgumentException) { return false; }
            
            // Whenever the client is ready, unlock the token configuration interface and load the user's avatar.
            DiscordInteractions.Client.Ready += () =>
            {
                // If the client doesn't, then don't do anything.
                if (DiscordInteractions.Client.CurrentUser == null) return Task.CompletedTask;

                Mainframe.Instance.Invoke(new MethodInvoker(() =>
                {
                    // Get the avatar URL and load it into the picture box.
                    string avatar_url = DiscordInteractions.Client.CurrentUser.GetAvatarUrl();
                    LockerAdditionInterface.Instance.PictureLoading.Load(avatar_url);

                    // Enable the token configuration interface and change the control states.
                    TokenConfigurationInterface.Instance.TextBoxToken.Enabled = true;
                    Mainframe.Instance.ChangeControlStates(true);
                }));
                
                return Task.CompletedTask;
            };

            DiscordInteractions.Client.Disconnected += (e) =>
            {
                // If the client is disconnected, then we disable the token configuration interface and show a warning.
                Mainframe.Instance.Invoke(new MethodInvoker(() =>
                {
                    LockerAdditionInterface.Instance.PictureLoading.Image = Image.FromFile("./assets/warning.png");
                    TokenConfigurationInterface.Instance.TextBoxToken.Enabled = true;
                }));

                DiscordInteractions.Client.StopAsync();
                return Task.CompletedTask;
            };

            return true;
        }

        /// <summary>
        /// Logs a message to the console.
        /// </summary>
        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}