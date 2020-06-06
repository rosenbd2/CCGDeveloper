using CCGDeveloper.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCGDeveloper.Classes
{
    abstract class Source : ISource
    {
        protected string sourceFilePath;
        protected Settings settings = new Settings();

        public abstract Document ReadData();
    }
}
