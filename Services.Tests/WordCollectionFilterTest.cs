using NUnit.Framework;
using Services.Entities;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Tests
{
    [TestFixture]
    public class WordCollectionFilterTest
    {
        
        [TestCase]
        public void FilterWords_TrimEdges()
        {
            // Arrange
            List<string> inputWords = new List<string> { "Spin", "Spit", "Spat", "Spot", "Span" };
            var startWord = FourLettersWord.Create("Spit");
            var endWord = FourLettersWord.Create("Spot");

            // Act
            var result = WordCollectionFilter.GetFourLettersWordsFromStartToEnd(inputWords, startWord, endWord);

            //Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result.Count(x => x.Word == startWord.Word));
            Assert.AreEqual(1, result.Count(x => x.Word == endWord.Word));
            Assert.AreEqual(1, result.Count(x => string.Equals(x.Word, "Spat", StringComparison.InvariantCultureIgnoreCase)));
            
        }

        [TestCase]
        public void FilterWords_RemoveLongWords()
        {
            // Arrange
            List<string> inputWords = new List<string> { "Spit", "Splash", "Spot" };
            var startWord = FourLettersWord.Create("Spit");
            var endWord = FourLettersWord.Create("Spot");

            // Act
            var result = WordCollectionFilter.GetFourLettersWordsFromStartToEnd(inputWords, startWord, endWord);

            //Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result.Count(x => x.Word == startWord.Word));
            Assert.AreEqual(1, result.Count(x => x.Word == endWord.Word));
            Assert.AreEqual(0, result.Count(x => string.Equals(x.Word, "Splash", StringComparison.InvariantCultureIgnoreCase)));

        }

        [TestCase]
        public void FilterWords_RemoveShortWords()
        {
            // Arrange
            List<string> inputWords = new List<string> { "Spit", "Sky", "Spot" };
            var startWord = FourLettersWord.Create("Spit");
            var endWord = FourLettersWord.Create("Spot");

            // Act
            var result = WordCollectionFilter.GetFourLettersWordsFromStartToEnd(inputWords, startWord, endWord);

            //Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result.Count(x => x.Word == startWord.Word));
            Assert.AreEqual(1, result.Count(x => x.Word == endWord.Word));
            Assert.AreEqual(0, result.Count(x => string.Equals(x.Word, "Sky", StringComparison.InvariantCultureIgnoreCase)));

        }

        [TestCase]
        public void FilterWords_WordsNotInOrder()
        {
            // Arrange
            List<string> inputWords = new List<string> { "hello","ajax","Spit", "Sky", "Spot", "spit" };
            var endWord = FourLettersWord.Create("Spit");
            var startWord = FourLettersWord.Create("Spot");

            // Act
            var result = WordCollectionFilter.GetFourLettersWordsFromStartToEnd(inputWords, startWord, endWord);

            //Assert
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(0, result.Count(x => string.Equals(x.Word, "hello", StringComparison.InvariantCultureIgnoreCase)));
            Assert.AreEqual(0, result.Count(x => string.Equals(x.Word, "Sky", StringComparison.InvariantCultureIgnoreCase)));

        }
    }
}
