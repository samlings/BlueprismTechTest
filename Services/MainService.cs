using Insfrastructure;
using Services.Entities;
using Services.Helpers;
using System.Linq;

namespace Services
{
    public class MainService
    {
        private readonly IFileReader fileReader;
        private readonly IFourLettersService fourLettersService;
        private readonly IFileWriter fileWriter;

        public MainService(IFileReader fileReader, IFourLettersService fourLettersService, IFileWriter fileWriter)
        {
            this.fileReader = fileReader;
            this.fourLettersService = fourLettersService;
            this.fileWriter = fileWriter;
        }

        public void Process(string inputFileName, FourLettersWord startWord, FourLettersWord endWord, string outputFileName)
        {
            var words = fileReader.GetWordsFromFile(inputFileName);

            var wordsFiltered = WordCollectionFilter.GetFourLettersWordsFromStartToEnd(words, startWord, endWord);
            
            var resultWords = fourLettersService.GetShortesListOfFourLetters(wordsFiltered, startWord, endWord);

            fileWriter.WriteWordsToFile(outputFileName, resultWords.Select(x => x.Word).ToList());
           
        }
    }
}
