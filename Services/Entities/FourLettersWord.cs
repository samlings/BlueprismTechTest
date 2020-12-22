using Services.Helpers;

namespace Services.Entities
{
    public class FourLettersWord
    {
        public string Word { get; private set; }

        private FourLettersWord(string word)
        {
            Word = word;
        }
        public static FourLettersWord Create(string wordFourLetters)
        {
            GuardClauses.IsNotNullNorEmpty(wordFourLetters, nameof(wordFourLetters));
            GuardClauses.IsWordFourLetterLong(wordFourLetters, nameof(wordFourLetters));

            return new FourLettersWord(wordFourLetters.ToLower());
        }
    }
}
