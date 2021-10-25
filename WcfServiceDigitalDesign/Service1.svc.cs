using PersonalLibNet;
using System;
using System.Collections.Generic;

namespace WcfServiceDigitalDesign
{
    public class Service1 : IService1
    {
        public Dictionary<string, int> ConvertFile(string content)
        {
            DictionaryControllerLib dc = new DictionaryControllerLib();
            var cl = dc.MultiCalcualte(content);
            return cl;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}