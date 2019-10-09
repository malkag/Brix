using System;
using System.Collections.Generic;

namespace FindInFileLib
{
    public class WordsDicionary
    {
        Dictionary<string, int> _wordsDictionary = new Dictionary<string, int>(); //<word, matches counter>

        public WordsDicionary(string[] words)
        {
            foreach(string word in words)
            {
                AddWord(word);
            }
        }

        public void AddWord(string word)
        {
            string key = SortWord(word); //key will be the "sorted" word
            if (!_wordsDictionary.ContainsKey(key))
            {
                _wordsDictionary[key] = 1;
            }
            else
            {
                _wordsDictionary[key]++; //this word (or equivalents) already found, increase its counter
            }
        }

        public int FindMathces(string word)
        {
            string key = SortWord(word); //key is the "sorted" word
            return _wordsDictionary.ContainsKey(key) ? _wordsDictionary[key] : 0;
        }

        private string SortWord(string word) {
            char[] wordChars = word.ToCharArray();
            Array.Sort(wordChars);
            return new string(wordChars);
        }
    }
}
