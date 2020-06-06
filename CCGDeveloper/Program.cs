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
            var source = new SourceCSV();                               // Create an source file of type CSV
            var document = source.ReadData();                           // Create a common document from data in CSV
            var output = new OutputJSON(document);                      // Create an output file of type JSON
            output.SaveDocument();                                      // Save document to Output file
            Console.WriteLine();
        }
    }
}
