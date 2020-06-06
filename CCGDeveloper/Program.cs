using System;
using System.IO;
using System.Xml;
using CCGDeveloper.Classes;
using Microsoft.Extensions.Configuration;

namespace CCGDeveloper
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvSource = new SourceCSV();                                    // Create an source file of type CSV
            var document = csvSource.ReadData();                                // Create a common document from data in CSV

            var jsonOutput = new OutputJSON(document);                          // Create an output file of type JSON
            jsonOutput.SaveDocument();                                          // Save document to Output file

            var xmlOutput = new OutputXML(document);                            // Create an output file of type XML
            xmlOutput.SaveDocument();                                           // Save document to Output file


            var xmlSource = new SourceXML();                                    // Create XML Source file
            document = xmlSource.ReadData();                                    // Deserialise XML file into Document

            var jsonSource = new SourceJSON();                                  // Create JSON Source file
            document = jsonSource.ReadData();                                   // Deserialise JSON file into Document


            Console.WriteLine(document.ToString());
            Console.WriteLine();
        }
    }
}
