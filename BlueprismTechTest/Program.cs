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
            Console.WriteLine("This i");

            ServiceProvider serviceProvider = InitializeServicesContainer();

            while (true)
            {
                Console.WriteLine("Insert the input file name (full path):");
                string inputFile = Console.ReadLine();

                Console.WriteLine("Insert the start word");
                string startWord = Console.ReadLine();

                Console.WriteLine("Insert the end word");
                string endWord = Console.ReadLine();

                Console.WriteLine("Insert the outpu file name (full path):");
                string outputFile = Console.ReadLine();

                //if (inputWiresSequence == "exit")
                //{ return; }

                var startWordObj = FourLettersWord.Create(startWord);
                var endWordObj = FourLettersWord.Create(endWord);

                var mainService = serviceProvider.GetService<MainService>();
                mainService.Process(inputFile, startWordObj, endWordObj, outputFile);


                
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
