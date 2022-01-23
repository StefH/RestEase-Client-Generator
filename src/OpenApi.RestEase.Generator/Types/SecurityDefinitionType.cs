using System.ComponentModel;
using OpenApi.RestEase.Generator.Utils;

namespace OpenApi.RestEase.Generator.Types;

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