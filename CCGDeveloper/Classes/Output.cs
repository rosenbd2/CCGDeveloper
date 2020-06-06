using CCGDeveloper.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCGDeveloper.Classes
{
    abstract class Output : IOutput
    {
        protected Document _data;
        protected string targetFilePath;
        protected Settings settings = new Settings();

        public Output(Document inputData)
        {
            _data = inputData;
        }

        public abstract bool SaveDocument();
    }
}
