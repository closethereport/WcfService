using System.Collections.Generic;
using System.Linq;

namespace WordsHandler
{
    internal class FIleTreament
    {
        public IOrderedEnumerable<string> SortFile(Dictionary<string, int> dc)
        {
            var orderedThread = from l in dc.Keys
                                orderby dc[l] descending
                                select l;

            return orderedThread;
        }
    }
}