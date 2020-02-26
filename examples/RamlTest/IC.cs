using System;
using System.Collections.Generic;
using System.Text;
using SharpYaml.Serialization;

namespace RamlTest
{
    public class IgnoreCasetNamingConvention : IMemberNamingConvention
    {
        public StringComparer Comparer { get { return StringComparer.InvariantCultureIgnoreCase; } }

        public string Convert(string name)
        {
            return name;
        }
    }
}
