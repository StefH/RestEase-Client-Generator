using System.Collections.Generic;

namespace RestEaseClientGenerator.Models.Internal
{
    internal class RestEaseInterface
    {
        public string Name { get; set; }

        public string Namespace { get; set; }

        public string Summary { get; set; }

        public ICollection<RestEaseParameter> VariableInterfaceHeaders { get; set; } = new List<RestEaseParameter>();

        public ICollection<RestEaseInterfaceMethodDetails> Methods { get; set; } = new List<RestEaseInterfaceMethodDetails>();

        public ICollection<RestEaseModel> InlineModels { get; set; } = new List<RestEaseModel>();
    }
}