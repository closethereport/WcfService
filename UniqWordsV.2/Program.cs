using PersonalLib;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace UniqWordsV._2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var input = new StreamReader("RawFile.txt"))
            {
                var contents = input.ReadToEnd()
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
                                                .Split(' ');

                var CalculateWords = typeof(DictionaryControllerLib).GetMethod("CalculateWords", BindingFlags.NonPublic | BindingFlags.Instance);
                var dict = (Dictionary<string, int>)CalculateWords.Invoke(new DictionaryControllerLib(), new object[] { contents });
                
                var ordered = from k in dict.Keys
                              orderby dict[k] descending
                              select k;
                using (StreamWriter output = new StreamWriter("output.txt"))
                {
                    foreach (var k in ordered)
                    {
                        output.WriteLine(string.Format("{0}:  {1}", k, dict[k]));
                    }
                }
            }
        }
    }
}