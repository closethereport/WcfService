using System.Collections.Generic;

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
    }
}