using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalLib
{
    public class DictionaryControllerLib
    {
        private Dictionary<string, int> CalculateWords(string[] contents)
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

        public Dictionary<string, int> MultithreadingCalculate(string[] contents)
        {
            Task.Factory.StartNew(() =>
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
            });
            return null;
        }
    }
}