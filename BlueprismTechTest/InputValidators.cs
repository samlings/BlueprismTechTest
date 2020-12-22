namespace BlueprismTechTest
{
    public static class InputValidators
    {
        public static bool IsFourLetterWordValid(string word)
        {
            return word.Trim().Length == 4;
        }
    }
}
