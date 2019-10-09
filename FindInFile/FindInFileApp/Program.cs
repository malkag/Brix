using System;
using System.Text.RegularExpressions;
using FindInFileLib;

namespace FindInFileApp
{
    class Program
    {
        static Regex r = new Regex("^[a-zA-Z0-9]*$");
        static void Main(string[] args)
        {
            StringsFile.CreateFileIfNotExist();
            WordsDicionary wordsDictionary = new WordsDicionary(StringsFile.ReadLines());

            Console.Write("Search for a word (5 alphnumeric characters) >> ");
            string word = Console.ReadLine();
            while (word != "exit") //change to string compaee
            {
                if (word.Length != 5)
                    Console.WriteLine("Word's length must be exactly 5 alphanumerical characters!");
                else if (!r.IsMatch(word))
                    Console.WriteLine("Word must contains alphanumerical characters only!");
                else
                {
                    int matchesCnt = wordsDictionary.FindMathces(word);
                    string matchStr = matchesCnt == 0 ? "was not found in file." : $"was found in the file {matchesCnt} times.";
                    Console.WriteLine($"Word \"{word}\" (or equivalents) {matchStr}");
                }

               Console.Write("Search for a word (5 alphnumeric characters) >> ");
               word = Console.ReadLine();
            }
        }
    }
}
