using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Helpers
{
    public class WordCollectionFilter
    {
        public static List<FourLettersWord> GetFourLettersWordsFromStartToEnd(List<string> rawWords, FourLettersWord startWord, FourLettersWord endWord)
        {
            if (rawWords is null)
            {
                throw new ArgumentNullException(nameof(rawWords));
            }

            var fourLettersOnlyLower = rawWords.Where(x => x.Length == 4).ToList().Select(x => x.ToLower()).ToList();

            var startIndex = fourLettersOnlyLower.IndexOf(startWord.Word);
            var endIndex = fourLettersOnlyLower.IndexOf(endWord.Word);
            if (endIndex < startIndex)
            {
                return fourLettersOnlyLower.Select(x => FourLettersWord.Create(x)).ToList(); ;
            }

            if (startIndex != -1)
            {
                var wordsFromStartWordReversed = fourLettersOnlyLower.Skip(startIndex).Reverse();
                endIndex = wordsFromStartWordReversed.ToList().IndexOf(endWord.Word);
                if (endIndex != -1)
                {
                    var wordsFromStartToEndWord = wordsFromStartWordReversed.Skip(endIndex);
                    return wordsFromStartToEndWord.Reverse().Select(x => FourLettersWord.Create(x)).ToList();
                }

                return wordsFromStartWordReversed.Reverse().Select(x => FourLettersWord.Create(x)).ToList();
            }

            return fourLettersOnlyLower.Select(x => FourLettersWord.Create(x)).ToList();
            
        }
    }
}
