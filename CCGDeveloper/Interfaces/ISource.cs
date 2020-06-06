using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CCGDeveloper.Interfaces
{
    interface ISource
    {
        public Stream ReadData();               // Reads all data from Source, e.g. CSV file, DB, etc
    }
}
