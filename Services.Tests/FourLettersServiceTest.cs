using NUnit.Framework;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Tests
{
    [TestFixture]
    public class FourLettersServiceTest
    {
        private FourLettersService _sut;

        public FourLettersServiceTest()
        {
            _sut = new FourLettersService();
        }
        

        [TestCase]
        public void GetShortestList_HappyPath()
        {
            // Arrange
            List<string> inputWordsRaw = new List<string> { "Spin", "Spit", "Spat", "Spot", "Span" };
            var inputWords = inputWordsRaw.Select(x => FourLettersWord.Create(x)).ToList();
            var startWord = FourLettersWord.Create("Spin");
            var endWord = FourLettersWord.Create("Spot");

            // Act
            var result = _sut.GetShortesListOfFourLetters(inputWords, startWord, endWord);

            //Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result.Count(x => x.Word == startWord.Word));
            Assert.AreEqual(1, result.Count(x => x.Word == endWord.Word));
            Assert.AreEqual(1, result.Count(x => string.Equals(x.Word, "Spit", StringComparison.InvariantCultureIgnoreCase)));
            Assert.AreEqual(0, result.Count(x => string.Equals(x.Word, "Span", StringComparison.InvariantCultureIgnoreCase)));
        }

        [TestCase]
        public void GetShortestList_WordsWithRepeatedLetters()
        {
            // Arrange
            List<string> inputWordsRaw = new List<string> { "Siin", "XpiP", "Tiin", "Oiin","Abcd","Oiii" };
            var inputWords = inputWordsRaw.Select(x => FourLettersWord.Create(x)).ToList();
            var startWord = FourLettersWord.Create("Siin");
            var endWord = FourLettersWord.Create("Oiii");

            // Act
            var result = _sut.GetShortesListOfFourLetters(inputWords, startWord, endWord);

            // Assert
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(1, result.Count(x => x.Word == startWord.Word));
            Assert.AreEqual(1, result.Count(x => x.Word == endWord.Word));
            Assert.AreEqual(1, result.Count(x => string.Equals(x.Word, "Tiin", StringComparison.InvariantCultureIgnoreCase)));
            Assert.AreEqual(1, result.Count(x => string.Equals(x.Word, "Oiin", StringComparison.InvariantCultureIgnoreCase)));
            Assert.AreEqual(0, result.Count(x => string.Equals(x.Word, "XpiP", StringComparison.InvariantCultureIgnoreCase)));
            Assert.AreEqual(0, result.Count(x => string.Equals(x.Word, "Abcd", StringComparison.InvariantCultureIgnoreCase)));
        }

        [TestCase]
        public void GetShortestList_FinalWordIsFoundEarly()
        {
            // Arrange
            List<string> inputWordsRaw = new List<string> { "Siin", "Oiin", "Oiil", "Oixl",  "Oixi", "Oiii" };
            var inputWords = inputWordsRaw.Select(x => FourLettersWord.Create(x)).ToList();
            var startWord = FourLettersWord.Create("Siin");
            var endWord = FourLettersWord.Create("Oiii");

            // Act
            var result = _sut.GetShortesListOfFourLetters(inputWords, startWord, endWord);

            // Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result.Count(x => x.Word == startWord.Word));
            Assert.AreEqual(1, result.Count(x => x.Word == endWord.Word));
            Assert.AreEqual(1, result.Count(x => string.Equals(x.Word, "Oiin", StringComparison.InvariantCultureIgnoreCase)));
            Assert.AreEqual(0, result.Count(x => string.Equals(x.Word, "Oiil", StringComparison.InvariantCultureIgnoreCase)));
            Assert.AreEqual(0, result.Count(x => string.Equals(x.Word, "Oixl", StringComparison.InvariantCultureIgnoreCase)));
            Assert.AreEqual(0, result.Count(x => string.Equals(x.Word, "Oixi", StringComparison.InvariantCultureIgnoreCase)));
        }

        [TestCase]
        public void GetShortestList_StartWordNotFound()
        {
            // Arrange
            List<string> inputWordsRaw = new List<string> { "abcd", "wxyz", "defg" };
            var inputWords = inputWordsRaw.Select(x => FourLettersWord.Create(x)).ToList();
            var startWord = FourLettersWord.Create("Siin");
            var endWord = FourLettersWord.Create("defg");

            // Act
            var result = _sut.GetShortesListOfFourLetters(inputWords, startWord, endWord);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestCase]
        public void GetShortestList_EndWordNotFound()
        {
            // Arrange
            List<string> inputWordsRaw = new List<string> { "abcd", "wxyz", "defg" };
            var inputWords = inputWordsRaw.Select(x => FourLettersWord.Create(x)).ToList();
            var startWord = FourLettersWord.Create("abcd");
            var endWord = FourLettersWord.Create("qwer");

            // Act
            var result = _sut.GetShortesListOfFourLetters(inputWords, startWord, endWord);

            // Assert
            Assert.AreEqual(0, result.Count);
        }
    }
}
