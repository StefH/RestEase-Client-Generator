using System;
using System.Collections.Generic;
using System.IO;
using SharpYaml.Serialization;

namespace OpenApiRamlConverter
{
    public class RamlConverter
    {
        public void X(Stream stream)
        {
            var serializer = new Serializer();

            var se = new SerializerSettings();
            

            var oboject = serializer.Deserialize(stream);


            var text = serializer.Serialize(new { List = new List<int>() { 1, 2, 3 }, Name = "Hello", Value = "World!" });
            Console.WriteLine(text);
        }
    }
}
