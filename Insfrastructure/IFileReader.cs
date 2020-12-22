using System.Collections.Generic;

namespace Insfrastructure
{
    public interface IFileReader
    {
        List<string> GetWordsFromFile(string filePath);
    }
}