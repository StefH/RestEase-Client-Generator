using System.Collections.Generic;

namespace RestEaseClientGenerator
{
    internal class RestEaseInterface
    {
        public string Name { get; set; }

        public string NameSpace { get; set; }

        public ICollection<RestEaseInterfaceMethodDetails> Methods { get; set; }
    }
}