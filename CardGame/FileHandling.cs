using System;
using System.Collections.Generic;
using System.IO;

namespace CardGames
{
    class FileHandling
    {
        private static readonly string rootPath = AppDomain.CurrentDomain.BaseDirectory;
        private static string fileName = "Winners.txt";

        public static void FileWrite(string winnerName)
        {
            File.AppendAllText(fileName, $"{winnerName}\n");
        }

        public static List<string> ReadFromFile()
        {
            List<string> winnerNames = new List<string>();
            string winnerName;
            StreamReader readFile = null;
            try
            {
                readFile = new StreamReader(Path.Combine(rootPath, fileName));
                do
                {
                    winnerName = readFile.ReadLine();
                    winnerNames.Add(winnerName);
                } while (winnerName != null);
                readFile.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No winners yet.");
            }
            return winnerNames;
        }
    }
}
