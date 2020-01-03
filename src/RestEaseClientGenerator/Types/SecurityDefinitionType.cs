using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Types
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum SecurityDefinitionType
    {
        [Description("None")]
        None,

        [Description("Header")]
        Header,

        [Description("Query")]
        Query
    }
}