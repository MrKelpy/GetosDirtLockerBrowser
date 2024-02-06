using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GetosDirtLocker.requests
{
    /// <summary>
    /// This is a kind of rough API Wrapper for the Discord API using user tokens.
    /// </summary>
    public static class DiscordInteractions
    {
        
        /// <summary>
        /// Tries to return the logged in user's uuid through its token, returning true if it succeeds.
        /// </summary>
        public static async Task<bool> IsTokenValid(string token)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bot " + token);
                await client.GetStringAsync("https://discord.com/api/users/@me");
            }
            catch (NullReferenceException) { return false; }
            catch (WebException) { return false; }

            return true;
        }
        
    }
}