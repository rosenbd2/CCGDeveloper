using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace CCGDeveloper.Classes
{
    // Generic document class which will hold data from any source
    class Document
    {
        private List<Detail> addresses = new List<Detail>();

        public List<Detail> Addresses
        {
           get { return addresses; }
        }
    }
}
