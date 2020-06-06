using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace CCGDeveloper.Classes
{
    // Generic document class which will hold data from any source
    [Serializable]
    public class Document
    {
        private List<Detail> addresses = new List<Detail>();

        [JsonProperty("addresses")]
        public List<Detail> Addresses
        {
           get { return addresses; }
        }
    }
}
