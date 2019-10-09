using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindInFileLib;

namespace FindInFileTest
{
    [TestClass]
    public class WordsDictionaryTest
    {
        [TestMethod]
        public void WordsDictionary_Test()
        {
            WordsDicionary wordsDictionary = new WordsDicionary(new string[] {"AaBb1", "abAB1", "A1abB", "123fR", "R1F23", "zzzXX" });

            Assert.AreEqual(wordsDictionary.FindMathces("AaBb1"), 3);
            Assert.AreEqual(wordsDictionary.FindMathces("1aAbB"), 3);

            Assert.AreEqual(wordsDictionary.FindMathces("123fR"), 1);

            Assert.AreEqual(wordsDictionary.FindMathces("xxZZZ"), 0);
            Assert.AreEqual(wordsDictionary.FindMathces("zXzXz"), 1);
        }
    }
}
