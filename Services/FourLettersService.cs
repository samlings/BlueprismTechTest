using Services.Entities;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class FourLettersService : IFourLettersService
    {
        private const int _wordLengthWithEqualLetters = 3;

        public FourLettersService()
        {

        }

        public List<FourLettersWord> GetShortesListOfFourLetters(List<FourLettersWord> inputFourLettersWords, FourLettersWord startWord, FourLettersWord endWord)
        {
            List<FourLettersWord> outputWords = new List<FourLettersWord>();
            if (inputFourLettersWords.Any(x => x.Word == startWord.Word))
            {
                outputWords.Add(startWord);
            }
            FourLettersWord previousWord = startWord;
            foreach (var currentWord in inputFourLettersWords)
            {
                if (IsEndWordFinalWord(endWord, previousWord))
                {
                    outputWords.Add(endWord);
                    return outputWords;
                }
                if (DoesWordDifferFromPreviousByOneLetterOnly(currentWord, previousWord))
                {
                    outputWords.Add(currentWord);
                    previousWord = currentWord;
                }
            }
            return outputWords;
        }

        private bool IsEndWordFinalWord(FourLettersWord endWord, FourLettersWord previousWord)
        {
            return DoesWordDifferFromPreviousByOneLetterOnly(endWord, previousWord);
        }

        private bool DoesWordDifferFromPreviousByOneLetterOnly(FourLettersWord currentWord, FourLettersWord previousWord)
        {
            var previousWordChars = previousWord.Word.ToCharArray().ToList();
            var currentWordChars = currentWord.Word.ToCharArray();
            int sumMatches = 0;
            for (int i = 0; i <= _wordLengthWithEqualLetters; i++)
            {
                bool charExists = previousWordChars.Contains(currentWordChars[i]);
                sumMatches += Convert.ToInt32(charExists);
                if (charExists)
                {
                    var index = previousWordChars.IndexOf(currentWordChars[i]);
                    previousWordChars.RemoveAt(index);
                }
            }
            
            return sumMatches == _wordLengthWithEqualLetters;
        }
    }
}
