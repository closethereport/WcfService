using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordsHandler
{
    internal class FileWrite
    {
        public void WriteFile(IOrderedEnumerable<string> ordered, Dictionary<string, int> dict)
        {
            using (StreamWriter output = new StreamWriter("MultiOutput.txt"))
            {
                foreach (var l in ordered)
                {
                    output.WriteLine(string.Format("{0}:  {1}", l, dict[l]));
                }
            }
        }
    }
}