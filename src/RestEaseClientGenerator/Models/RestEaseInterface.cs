using System.Collections.Generic;

namespace RestEaseClientGenerator.Models
{
    internal class RestEaseInterface
    {
        public string Name { get; set; }

        public string Namespace { get; set; }

        public ICollection<RestEaseInterfaceMethodDetails> Methods { get; set; }
    }
}