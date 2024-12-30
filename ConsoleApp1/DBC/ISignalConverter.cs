using System;
using System.Collections.Generic;
using System.Text;

namespace DBCParser
{
    public interface ISignalConverter
    {
        public double Value { get; set; }
        public string Name { get; set; }
    }
}
