namespace WordsHandler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FileReader fr = new FileReader();
            FIleTreament ft = new FIleTreament();
            FileWrite fw = new FileWrite();

            string path = "Rawfile.txt";

            var data = fr.ReadFromFile(path);

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            var ret = client.ConvertFile(data);
            client.Close();

            var threatedfile = ft.SortFile(ret);

            fw.WriteFile(threatedfile, ret);

            //var SingleCalculate = typeof(DictionaryControllerLib).GetMethod("SingleCalculate", BindingFlags.NonPublic | BindingFlags.Instance);
            //var SingleDict = (Dictionary<string, int>)SingleCalculate.Invoke(new DictionaryControllerLib(), new object[] { singlecontent });
        }
    }
}