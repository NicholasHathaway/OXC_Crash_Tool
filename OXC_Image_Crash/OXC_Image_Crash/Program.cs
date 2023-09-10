using I_Support_KKK;
using Newtonsoft.Json.Linq;
using OXC_Crash_Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace OXC_Image_Crash
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            ConsoleHandler.Load();

            AppDomain.CurrentDomain.ProcessExit += ProcessExitHandler;

            ExtractBots.StartUp();

            //Bot.AddBot("authcookie_7d59e92a-ab14-43c6-bacc-55957bdb7999");
            //Bot.AddBot("authcookie_6ba24c29-a67b-4603-9d45-e3555cc4c830");
            //Bot.AddBot("authcookie_cb9d278b-13c6-439f-9fab-df4ff5c4795b");
           // Bot.AddBot("authcookie_c1198837-371a-462b-a8ad-a94d2282933c");
           // Bot.AddBot("authcookie_32c0095b-5861-4aed-8fca-8fba1eda5a22");
           // Bot.AddBot("authcookie_d3dd00b1-01c7-4cf7-b78e-2ccbd138b129");
          //  Bot.AddBot("authcookie_8b5981ad-46f2-404a-bb9f-f9bbd1b846b3");
          //  Bot.AddBot("authcookie_bec1852d-6dc2-4edf-9a60-804d4eda2956");
          //  Bot.AddBot("authcookie_04532643-581b-4218-b1d8-c0fb3f95d283");
         //   Bot.AddBot("authcookie_7d39b7e7-19f8-49b0-b7b6-86be25c41112");

            GUI_Renderer GUI = new GUI_Renderer();
            Thread UI_ = new Thread(() => GUI.Start().Wait()); UI_.Start();

            while (true)
            {
                Console.ReadKey();
            }
        }
        static void ProcessExitHandler(object sender, EventArgs e)
        {
            foreach (BotClient botClient in Bot.BotClients)
            {
                API.SetAvatar(botClient, Config.DefaulAvatarID);
            }
        }
    }
}
