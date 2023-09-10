using I_Support_KKK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace OXC_Image_Crash
{
    public class ConsoleHandler
    {
        public static void Load()
        {
            Thread TitleThread = new Thread(Title);
            TitleThread.Start();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@".d88b. Yb  dP .d88b    888b.        w        ");
            Console.WriteLine(@"8P  Y8  YbdP  8P       8wwwP .d8b. w8ww d88b ");
            Console.WriteLine(@"8P  Y8  YbdP  8P       8wwwP .d8b. w8ww d88b ");
            Console.WriteLine(@"`Y88P' dP  Yb `Y88P    888P' `Y8P'  Y8P Y88P ");
            Console.WriteLine("");
            Console.WriteLine(@"                 by dll.gg                   ");
            Console.WriteLine("");
            Console.ResetColor();
        }
        private static void Title()
        {
            while (true)
            {
                Console.Title = $"[OXC] Press Tab to Toggle Menu [Available Bots {Bot.BotClients.Count}]";
                Thread.Sleep(100);
            }
        }
        public static void Log(object Message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{DateTime.Now.ToString()}] " + Message);
            Console.ResetColor();
        }
        public static void LogSuccess(object Message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now.ToString()}] " + Message);
            Console.ResetColor();
        }
        public static void LogError(object Message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{DateTime.Now.ToString()}] " + Message);
            Console.ResetColor();
        }
        public static void LogDebug(object Message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"[{DateTime.Now.ToString()}] " + Message);
            Console.ResetColor();
        }
        public static void LogMenu(object Message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[{DateTime.Now.ToString()}] " + Message);
            Console.ResetColor();
        }
        public static void LogWarning(object Message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{DateTime.Now.ToString()}] " + Message);
            Console.ResetColor();
        }
    }
}
