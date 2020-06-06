using System;
using System.Collections.Generic;
using System.Text;

namespace CCGDeveloper.Classes
{
    // Each line in a Document
    class Detail
    {

        private string name;
        private Address address = new Address();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Address TheAddress
        {
            get { return address; }
        }
    }

    public class Address
    {
        private string line1;
        private string line2;

        public string Line1
        {
            get { return line1; }
            set { line1 = value; }
        }

        public string Line2
        {
            get { return line2; }
            set { line2 = value; }
        }
    }
}
