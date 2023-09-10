using OXC_Image_Crash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Support_KKK
{
    public class Bot
    {
        public static List<BotClient> BotClients = new List<BotClient>();
        public static void RemoveBot(string token)
        {
            BotClient botToRemove = Bot.BotClients.FirstOrDefault(bot => bot._token == token);
            if (botToRemove != null)
            {
                Bot.BotClients.Remove(botToRemove);
            }
        }
        public static void AddBot(string token)
        {
            string Validation = API.ValidateAuthcookie(token);
            if (Validation == null)
            {
                if (GUI_Renderer.logerror)
                {
                    ConsoleHandler.LogError($"[{token}] is an [Invalid/Banned] Token");
                }
            }
            else
            {
                string username = API.GetUserName(token);
                if (GUI_Renderer.logsuccess)
                {
                    ConsoleHandler.LogSuccess($"Verfied [{token}]");
                    ConsoleHandler.LogSuccess($"ADDED [{username}]");
                    Console.WriteLine("");
                }
                BotClients.Add(new BotClient(token, API.GetUserId(token), username));
            }
        }
    }
    public class BotClient
    {
        public readonly string _token;
        public readonly string _userid;
        public readonly string _displayname;
        public BotClient(string token, string userid, string displayname)
        {
            _token = token;
            _userid = userid;
            _displayname = displayname;
        }
    }

}
