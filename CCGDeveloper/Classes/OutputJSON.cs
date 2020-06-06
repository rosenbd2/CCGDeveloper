using CCGDeveloper.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCGDeveloper.Classes
{
    class OutputJSON : IOutput
    {
        private Document _data;
        private string targetFilePath;
        public OutputJSON(Document inputData)
        {
            _data = inputData;    
            var settings = new Settings();
            targetFilePath = settings.Configuration.GetSection("JSONTargetFile").Value;
        }
        public bool SaveDocument()
        {
            throw new NotImplementedException();
        }
    }
}
