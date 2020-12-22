using Services.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface IFourLettersService
    {
        List<FourLettersWord> GetShortesListOfFourLetters(List<FourLettersWord> inputFourLettersWords, FourLettersWord startWord, FourLettersWord endWord);
    }
}