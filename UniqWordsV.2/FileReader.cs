using System.IO;

namespace UniqWordsV._2
{
    public class FileReader
    {
        public string[] SingleThreaded()
        {
            using (var input = new StreamReader("RawFile.txt"))
            {
                var singlecontent = input.ReadToEnd()
                                                .ToLower()
                                                .Replace("/[0-9]", "")
                                                .Replace(",", "")
                                                .Replace(".", "")
                                                .Replace("(", "")
                                                .Replace(")", "")
                                                .Replace(".", "")
                                                .Replace("-", "")
                                                .Replace(":", "")
                                                .Replace("  ", "")
                                                .Replace("\"", "")
                                                .Split(' ');

                return singlecontent;
            }
        }

        public string[] MultiThreaded()
        {
            using (var input = new StreamReader("RawFile.txt"))
            {
                var multicontent = input.ReadToEnd()
                                                .ToLower()
                                                .Replace("/[0-9]", "")
                                                .Replace(",", "")
                                                .Replace(".", "")
                                                .Replace("(", "")
                                                .Replace(")", "")
                                                .Replace(".", "")
                                                .Replace("-", "")
                                                .Replace(":", "")
                                                .Replace("  ", "")
                                                .Replace("\"", "")
                                                .Split(' ');

                return multicontent;
            }
        }
    }
}