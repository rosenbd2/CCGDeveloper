using CCGDeveloper.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CCGDeveloper.Interfaces
{
    interface ISource
    {
        public Document ReadData();               // Reads all data from Source, e.g. CSV file, DB, etc
    }
}
