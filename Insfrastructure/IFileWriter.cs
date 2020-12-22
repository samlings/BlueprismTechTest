using System.Collections.Generic;

namespace Insfrastructure
{
    public interface IFileWriter
    {
        void WriteWordsToFile(string filePath, List<string> words);
    }
}