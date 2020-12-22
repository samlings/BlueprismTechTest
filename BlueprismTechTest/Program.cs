using Insfrastructure;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Entities;
using System;

namespace BlueprismTechTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = InitializeServicesContainer();

            Console.WriteLine("This program calculates the shortest list of four letter words.");

            while (true)
            {
                Console.WriteLine("Insert the file name of a text file containing four letter words (full path):");
                string inputFile = Console.ReadLine();

                Console.WriteLine("Insert the start word (four letter word):");
                string startWord = Console.ReadLine();
                if (!InputValidators.IsFourLetterWordValid(startWord))
                {
                    Console.WriteLine("The end word shoud have 4 letters. Try again");
                    continue;
                }

                Console.WriteLine("Insert the end word (four letter word):");
                string endWord = Console.ReadLine();
                if (!InputValidators.IsFourLetterWordValid(endWord))
                {
                    Console.WriteLine("The end word shoud have 4 letters. Try again");
                    continue;
                }

                Console.WriteLine("Insert the file name of a text file that will contain the result (full path):");
                string outputFile = Console.ReadLine();

                try
                {
                    var startWordObj = FourLettersWord.Create(startWord);
                    var endWordObj = FourLettersWord.Create(endWord);
                    var mainService = serviceProvider.GetService<MainService>();
                    mainService.Process(inputFile, startWordObj, endWordObj, outputFile);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error ocurred. Please try again. ({ex.Message})");
                    continue;
                }

                Console.WriteLine("Great! Your result file was created successfully.");
                return;
            }
        }

        private static ServiceProvider InitializeServicesContainer()
        {
            return new ServiceCollection()
                .AddScoped<MainService>()
                .AddScoped<IFourLettersService,FourLettersService>()
                .AddScoped<IFileReader,FileManager>()
                .AddScoped<IFileWriter, FileManager>()
                .BuildServiceProvider();
        }
    }
}
