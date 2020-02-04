using System.Collections.Generic;

namespace RestEaseClientGenerator.Models.Internal
{
    public class RestEaseEnum
    {
        public string Namespace { get; set; }

        public string EnumName { get; set; }

        public ICollection<string> Values { get; set; }

        public string RawValue { get; set; }
    }
}