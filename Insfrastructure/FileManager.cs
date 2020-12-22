using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Insfrastructure
{
    public class FileManager : IFileReader, IFileWriter
    {

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public List<string> GetWordsFromFile(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }
        public void WriteWordsToFile(string filePath, List<string> words)
        {
            //throw new NotImplementedException();
        }
    }
}
