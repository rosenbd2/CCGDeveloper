using CCGDeveloper.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection.Metadata;
using System.Linq;
using System.Xml.Serialization;

namespace CCGDeveloper.Classes
{
    class OutputXML : Output
    {
        public OutputXML(Document inputData):base(inputData)
        {
            targetFilePath = settings.Configuration.GetSection("XMLTargetFile").Value;
        }

        public override bool SaveDocument()
        {
            try
            {
                if (File.Exists(targetFilePath))
                {
                    File.Delete(targetFilePath);
                }

                XmlSerializer xmlSerializer = new XmlSerializer(_data.GetType());

                using (StreamWriter writer = new StreamWriter(targetFilePath))
                {
                    xmlSerializer.Serialize(writer, _data);
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
