using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CCGDeveloper.Classes
{
    // Returns settings from Json File
    class Settings
    {
        private readonly IConfigurationRoot _configuration;

        public Settings()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("Settings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();

            // var val1 = builder.Build().GetSection("Group").GetSection("SpecificValue6").Value;
        }

        public IConfigurationRoot Configuration
        {
            get
            {
                return _configuration;
            }
        }
    }
}
