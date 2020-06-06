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

        public string ToXML()
        {
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(_data.GetType());
                serializer.Serialize(stringwriter, _data);
                return stringwriter.ToString();
            }
        }
        public Document ReadXMLIntoDocument(string xmlText) 
        {
            using (var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(_data.GetType());
                return serializer.Deserialize(stringReader) as Document;
            }
        }
    }
}
