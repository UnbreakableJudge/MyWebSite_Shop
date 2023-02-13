
using System.Runtime.Serialization;

namespace MyWebSite_Shop.Models
{
    [DataContract]
    public class ModelDescriptionJson
    {
        [DataMember]
        public string MajorNameField { get; set; } = "1";
        [DataMember]
        public string DescriptionNameField { get; set; } = "";
        [DataMember]
        public string DescriptionField { get; set; } = "";
        public void Output()
        {
            Console.WriteLine("M: " + MajorNameField + " DescName" + DescriptionNameField + " DescriptionField" + DescriptionField);
        }
    }
}
