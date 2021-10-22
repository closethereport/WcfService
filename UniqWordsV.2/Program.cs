using PersonalLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace UniqWordsV._2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DictionaryControllerLib dc = new DictionaryControllerLib();
            FileReader fl = new FileReader();
            string[] singlecontent = fl.SingleThreaded();
            string[] multicontent = fl.MultiThreaded();
            var sw = new Stopwatch();
            var swThread = new Stopwatch();

            sw.Start();
            var SingleCalculate = typeof(DictionaryControllerLib).GetMethod("SingleCalculate", BindingFlags.NonPublic | BindingFlags.Instance);
            var SingleDict = (Dictionary<string, int>)SingleCalculate.Invoke(new DictionaryControllerLib(), new object[] { singlecontent });

            var ordered = from k in SingleDict.Keys
                          orderby SingleDict[k] descending
                          select k;
            using (StreamWriter output = new StreamWriter("SingleOutput.txt"))
            {
                foreach (var k in ordered)
                {
                    output.WriteLine(string.Format("{0}:  {1}", k, SingleDict[k]));
                }
            }
            sw.Stop();
            Console.WriteLine("Без использования потоков :" + " " + sw.Elapsed);

            swThread.Start();
            var MultiDict = dc.MultiCalcualte(multicontent);
            swThread.Stop();
            Console.WriteLine("С использованием потоков :" + " " + swThread.Elapsed);

            var orderedThread = from l in MultiDict.Keys
                                orderby MultiDict[l] descending
                                select l;
            using (StreamWriter output = new StreamWriter("MultiOutput.txt"))
            {
                foreach (var l in orderedThread)
                {
                    output.WriteLine(string.Format("{0}:  {1}", l, MultiDict[l]));
                }
            }
        }
    }
}