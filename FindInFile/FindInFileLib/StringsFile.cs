using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FindInFileLib
{
    public static class StringsFile
    {
        const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly IEnumerable<string> _repeatedChars = Enumerable.Repeat(_chars, 5);
        const string FILE_NAME = "string.txt"; //will be created on working directory
        private static readonly Random _random = new Random();
        
        public static void CreateFileIfNotExist()
        {
            if (!File.Exists(FILE_NAME))
            {
                CreateFile();
            }
        }

        public static string[] ReadLines()
        {
           return File.ReadAllLines(FILE_NAME);
        }

        private static void CreateFile()
        {
            const int LINES_NUM = 1000000;

            using (StreamWriter sw = File.CreateText(FILE_NAME))
            {
                for (int i = 0; i <= LINES_NUM; i++)
                {
                    string randWord = CreateRandomWord();
                    sw.WriteLine(randWord);
                }
            }
        }

        private static string CreateRandomWord()
        {
            return new string(_repeatedChars.Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
