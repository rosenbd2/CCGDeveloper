using CCGDeveloper.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace CCGDeveloper.Classes
{
    class SourceCSV : ISource
    {
        private string sourceFilePath;

        private string[] headingNames;
        private string[] headingGroupNames;

        public SourceCSV()
        {
            var settings = new Settings();
            sourceFilePath = settings.Configuration.GetSection("CSVSourceFile").Value;
        }

        // Read the CSV file and convert it into a Document
        public Document ReadData()
        {
            var theDocument = new Document();
            using (TextFieldParser parser = new TextFieldParser(sourceFilePath))
            {
                bool processedHeadings = false;
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    if (!processedHeadings)
                    {
                        // Process the headings and Groups
                        ProcessHeadings(parser.ReadFields(), theDocument);
                        processedHeadings = true;
                    }
                    else
                    {
                        // Process Data Row
                        ProcessDataRow(parser.ReadFields(), theDocument);
                    }
                }
            }

            return theDocument;
        }

        private void ProcessHeadings(string[] headings, Document theDocument)
        {
            headingNames = new string[headings.Length];
            headingGroupNames = new string[headings.Length];

            string name;
            string group;
            for (int x = 0; x < headings.Length; x++)
            {
                // discover groups
                if (headings[x].Contains("_"))
                {
                    string[] groupAndHeading = headings[x].Split("_");
                    group = groupAndHeading[0];
                    name = groupAndHeading[1];
                }
                else
                {
                    group = "";
                    name = headings[x];
                }
                headingGroupNames[x] = group;
                headingNames[x] = name;
            }
        }

        private void ProcessDataRow(string[] dataValues, Document theDocument)
        {
            Detail theRow = new Detail();
            for (int x = 0; x < dataValues.Length; x++)
            {
                AssingValueToPropertyDynamically(theRow, headingGroupNames[x], headingNames[x], dataValues[x]);
            }
            theDocument.Addresses.Add(theRow);
        }

        // This method assigns (semi) dynamically values to properties
        private void AssingValueToPropertyDynamically(Detail theRow, string groupName, string propertyName, string propertyValue)
        {
            propertyName = char.ToUpper(propertyName[0]) + propertyName.Substring(1);

            PropertyInfo property;

            if (string.IsNullOrEmpty(groupName))
            {
                // property without group
                property = theRow.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
                if (null != property && property.CanWrite)
                {
                    property.SetValue(theRow, propertyValue, null);
                }
            }
            else
            {
                // property within group (address)
                property = theRow.TheAddress.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
                if (null != property && property.CanWrite)
                {
                    property.SetValue(theRow.TheAddress, propertyValue, null);
                }
            }
        }
    }
}
