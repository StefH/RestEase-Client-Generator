using System.Collections.Generic;

namespace RestEaseClientGenerator.Models.Internal
{
    internal class RestEaseInterfaceMethod
    {
        public string ReturnType { get; set; }

        public string Name { get; set; }

        // public string ParametersAsString { get; set; }

        public ICollection<RestEaseParameter> Parameters { get; set; }
    }
}