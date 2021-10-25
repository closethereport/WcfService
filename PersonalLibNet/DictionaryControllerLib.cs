using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalLibNet
{
    public class DictionaryControllerLib
    {
        //private Dictionary<string, int> SingleCalculate(string[] contents)
        //{
        //    var dict = new Dictionary<string, int>();
        //    foreach (var word in contents)
        //    {
        //        if (dict.ContainsKey(word))
        //        {
        //            dict[word]++;
        //        }
        //        else
        //        {
        //            dict[word] = 1;
        //        }
        //    }
        //    return dict;
        //}

        public Dictionary<string, int> MultiCalcualte(string data)
        {
            var wordsArr = FileClear(data);
            var dict = new ConcurrentDictionary<string, int>();

            Parallel.For(0, wordsArr.Length, i =>
            {
                dict.AddOrUpdate(wordsArr[i], 1, (key, oldValue) => oldValue + 1);
            });
            Dictionary<string, int> EndDict = dict.ToDictionary(pair => pair.Key, pair => pair.Value);
            return EndDict;
        }

        public string[] FileClear(string data)
        {
            var clearfile = data.ToLower()
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

            return clearfile;
        }
    }
}