using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DBCParser.Models
{
    public class ObjectPropertyModel
    {
        public object Obj { get; set; } = new();
        public PropertyInfo? Prop { get; set; }

    }
}
