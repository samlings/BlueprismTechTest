using System;

namespace Services.Helpers
{
    public static class GuardClauses
    {
        public static void IsNotNullNorEmpty(string word, string argumentName)
        {
            if (word == null)
                throw new ArgumentNullException(argumentName);
        }

        public static void IsWordFourLetterLong(string word, string argumentName)
        {
            if (word.Length != 4)
            {
                throw new ArgumentException($"'{nameof(word)}' must have 4 letters", nameof(argumentName));
            }
        }
    }
}
