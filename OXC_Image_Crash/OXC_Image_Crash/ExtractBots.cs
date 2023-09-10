using I_Support_KKK;
using OXC_Image_Crash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXC_Crash_Tool
{
    public class ExtractBots
    {
        public static void StartUp()
        {
            if (File.Exists("Tokens.txt"))
            {
                AuthCacheMethod();
            }
            else
            {
                ConsoleHandler.LogWarning("No Tokens.txt found");
                Console.WriteLine("");
                ConsoleHandler.Log("We Are Now Helping You Generate One!");
                Console.WriteLine("");
                ConsoleHandler.Log("Use /add to add Tokens || Usage = /add [authcookie]");
                ConsoleHandler.Log("Use /exit When You Are Done Adding Tokens!");
                Console.WriteLine("");
                List<string> tokens = new List<string>();
                bool addingTokens = true;

                while (addingTokens)
                {
                    string input = Console.ReadLine();
                    if (input.StartsWith("/exit"))
                    {
                        GenerateTokensFile(tokens);
                        Console.WriteLine("");
                        ConsoleHandler.Log("The Program Is Going to close in 3 Seconds...");
                        Thread.Sleep(1000);
                        ConsoleHandler.Log("The Program Is Going to close in 2 Seconds...");
                        Thread.Sleep(1000);
                        ConsoleHandler.Log("The Program Is Going to close in 1 Seconds...");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                    }
                    if (input.StartsWith("/add"))
                    {
                        if (input.Length > 5)
                        {
                            string[] inputConverted = input.Split(' ');
                            if(API.ValidateAuthcookie(inputConverted[1]) != null)
                            {
                                tokens.Add(inputConverted[1]);
                                ConsoleHandler.LogSuccess($"Successfully Added Token [{inputConverted[1]}]");
                            }
                            else
                            {
                                ConsoleHandler.LogError($"Invalid Token [{inputConverted[1]}]");
                            }
                        }
                        else
                        {
                            ConsoleHandler.LogError("Invalid token format. Please provide a valid token.");
                        }
                    }
                }
            }
        }
        public static void AuthCacheMethod()
        {
            List<string> tokens = File.ReadAllLines("Tokens.txt").ToList();
            if (tokens.Count == 0)
            {
                ConsoleHandler.LogWarning("No Tokens Found!");
            }
            else
            {
                foreach (var token in tokens)
                {
                    Bot.AddBot(token);
                }
            }
        }
        private const string fileName = "Tokens.txt";
        private static void GenerateTokensFile(List<string> tokens)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (string token in tokens)
                    {
                        writer.WriteLine(token);
                    }
                }

                ConsoleHandler.LogSuccess($"Tokens file generated successfully. Tokens written: {tokens.Count}");
            }
            catch (IOException ex)
            {
                ConsoleHandler.LogError($"Error generating Tokens file: {ex.Message}");
            }
        }
    }
}
