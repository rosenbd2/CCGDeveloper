using CCGDeveloper.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

namespace CCGDeveloper.Classes
{
    class SourceXML : Source
    {
        public SourceXML():base()
        {
            var settings = new Settings();
            sourceFilePath = settings.Configuration.GetSection("XMLSourceFile").Value;
        }

        // Read the XML file and deserialize it into a Document
        public override Document ReadData()
        {
            var theDocument = new Document();

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Document));
                using (FileStream reader = new FileStream(sourceFilePath, FileMode.Open))
                {
                    theDocument = (Document)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return theDocument;
        }
    }
}
