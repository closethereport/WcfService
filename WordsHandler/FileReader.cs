using System.IO;

namespace WordsHandler
{
    public class FileReader
    {
        public string ReadFromFile(string path)
        {
            var file = string.Empty;
            using (var input = new StreamReader(path))
                file += "" + input.ReadToEnd();

            return file;
        }
    }
}