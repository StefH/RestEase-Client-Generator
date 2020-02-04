using System.Collections.Generic;

namespace RestEaseClientGenerator.Models.Internal
{
    internal class RestEaseInterface
    {
        public string Name { get; set; }

        public string Namespace { get; set; }

        public string Summary { get; set; }

        public List<RestEaseInterfaceHeader> VariableHeaders { get; set; } = new List<RestEaseInterfaceHeader>();

        public List<RestEaseInterfaceQueryParameter> ConstantQueryParameters { get; set; } = new List<RestEaseInterfaceQueryParameter>();

        public ICollection<RestEaseInterfaceMethodDetails> Methods { get; set; } = new List<RestEaseInterfaceMethodDetails>();

        public ICollection<RestEaseModel> InlineModels { get; set; } = new List<RestEaseModel>();

        public ICollection<RestEaseEnum> InlineEnums { get; set; } = new List<RestEaseEnum>();
    }
}