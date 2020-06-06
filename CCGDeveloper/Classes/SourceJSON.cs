using CCGDeveloper.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CCGDeveloper.Classes
{
    class SourceJSON : Source
    {
        public SourceJSON():base()
        {
            var settings = new Settings();
            sourceFilePath = settings.Configuration.GetSection("JSONSourceFile").Value;
        }

        // Read the XML file and deserialize it into a Document
        public override Document ReadData()
        {
            var theDocument = new Document();

            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader reader = File.OpenText(sourceFilePath))
                {
                    theDocument = (Document)serializer.Deserialize(reader, typeof(Document));
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
