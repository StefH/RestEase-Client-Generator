using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Types;

[TypeConverter(typeof(EnumDescriptionConverter))]
public enum SecurityDefinitionType
{
    [Description("None")]
    None,

    [Description("Automatic")]
    Automatic,

    [Description("Fixed")]
    Fixed,

    [Description("Header")]
    Header,

    [Description("Query")]
    Query
}