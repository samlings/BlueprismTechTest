using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Helpers
{
    public class WordFiltering
    {
        public static List<FourLettersWord> GetFourLettersWordsFromStartToEnd(List<string> rawWords, FourLettersWord startWord, FourLettersWord endWord)
        {
            if (rawWords is null)
            {
                throw new ArgumentNullException(nameof(rawWords));
            }

            var fourLettersOnlyLower = rawWords.Where(x => x.Length == 4).ToList().Select(x => x.ToLower()).ToList();

            var startIndex = fourLettersOnlyLower.IndexOf(startWord.Word);
            if (startIndex != -1)
            {
                var partialOne = fourLettersOnlyLower.Skip(startIndex).Reverse().ToList();

                var endIndex = partialOne.IndexOf(endWord.Word);
                if (endIndex != -1)
                {
                    var partialTwo = partialOne.Skip(endIndex);
                    return partialTwo.Reverse().Select(x => FourLettersWord.Create(x)).ToList();
                }

                return partialOne.Select(x => FourLettersWord.Create(x)).ToList(); ;
            }

            return fourLettersOnlyLower.Select(x => FourLettersWord.Create(x)).ToList();
            
        }
    }
}
