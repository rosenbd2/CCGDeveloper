using CCGDeveloper.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CCGDeveloper.Classes
{
    class SourceCSV:ISource
    {
        private string sourceFilePath;
        public SourceCSV()
        {
            var settings = new Settings();
            sourceFilePath = settings.Configuration.GetSection("CSVSourceFolder").Value;
        }

        public Stream ReadData()
        {
            throw new NotImplementedException();
        }
    }
}
