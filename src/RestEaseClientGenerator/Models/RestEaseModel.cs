using System.Collections.Generic;

namespace RestEaseClientGenerator.Models
{
    internal class RestEaseModel
    {
        public string NameSpace { get; set; }

        public string ClassName { get; set; }

        public ICollection<string> Properties { get; set; }
    }
}