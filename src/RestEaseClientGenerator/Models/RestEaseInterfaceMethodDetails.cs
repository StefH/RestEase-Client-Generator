using System.Collections.Generic;

namespace RestEaseClientGenerator.Models
{
    internal class RestEaseInterfaceMethodDetails
    {
        public string Summary { get; set; }

        public ICollection<string> SummaryParameters { get; set; }

        public string RestEaseAttribute { get; set; }

        public RestEaseInterfaceMethod RestEaseMethod { get; set; }
    }
}