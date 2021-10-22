using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalLib
{
    public class DictionaryControllerLib
    {
        private static object locker = new object();

        private Dictionary<string, int> SingleCalculate(string[] contents)
        {
            var dict = new Dictionary<string, int>();
            foreach (var word in contents)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict[word] = 1;
                }
            }
            return dict;
        }

        public Dictionary<string, int> MultiCalcualte(string[] contents)
        {
            lock (locker)
            {
                var wordsArr = contents;
                var dict = new Dictionary<string, int>();
                Parallel.ForEach(wordsArr, (word) =>

                {
                    if (dict.ContainsKey(word))
                    {
                        dict[word]++;
                    }
                    else
                    {
                        dict[word] = 1;
                    }
                }
                    );
                return dict;
            }
        }
    }
}