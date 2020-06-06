using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CCGDeveloper.Classes
{
    // Each data row in a source document
    [Serializable]
    public class Detail
    {

        private string name;
        private Address address = new Address();

        [JsonProperty("name")]
        [XmlElement("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [XmlElement("address")]
        [JsonProperty("address")]
        public Address TheAddress
        {
            get { return address; }
            set { address = value; }
        }
    }

    [Serializable]
    public class Address
    {
        private string line1;
        private string line2;

        [JsonProperty("line1")]
        [XmlElement("line1")]
        public string Line1
        {
            get { return line1; }
            set { line1 = value; }
        }

        [JsonProperty("line2")]
        [XmlElement("line2")]
        public string Line2
        {
            get { return line2; }
            set { line2 = value; }
        }
    }
}
