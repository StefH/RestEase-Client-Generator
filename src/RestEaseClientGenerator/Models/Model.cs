using System.Collections.Generic;

namespace RestEaseClientGenerator
{
    internal class Model
    {
        public string NameSpace { get; set; }

        public string ClassName { get; set; }

        public ICollection<string> Properties { get; set; }
    }
}