using CCGDeveloper.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace CCGDeveloper.Classes
{
    class OutputJSON : Output
    {

        public OutputJSON(Document inputData) : base(inputData)
        {
            targetFilePath = settings.Configuration.GetSection("JSONTargetFile").Value;
        }

        public override bool SaveDocument()
        {
            try
            {
                if (File.Exists(targetFilePath))
                {
                    File.Delete(targetFilePath);
                }
                
                string serialisedDocument = JsonConvert.SerializeObject(_data);
                using (var writer = new StreamWriter(targetFilePath, true))
                {
                    writer.WriteLine(serialisedDocument.ToString());
                    writer.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
