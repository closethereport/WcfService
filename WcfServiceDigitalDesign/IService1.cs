using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServiceDigitalDesign
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Dictionary<string, int> ConvertFile(string content);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }

    [DataContract]
    public class CompositeType
    {
        private bool boolValue = true;
        private string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}