using logReporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBCParser.Attributes
{
    [AttributeUsage(AttributeTargets.Field |
               AttributeTargets.Property)]
    public class DBCSignalAttribute : Attribute
    {
        public string Key;
        public DBCSignalAttribute(string key)
        {
            Key = key;
        }
    }
}
