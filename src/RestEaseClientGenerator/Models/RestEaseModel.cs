using System.Collections.Generic;

namespace RestEaseClientGenerator.Models
{
    internal class RestEaseModel
    {
        public string Namespace { get; set; }

        public string ClassName { get; set; }

        public ICollection<string> Properties { get; set; }
    }
}