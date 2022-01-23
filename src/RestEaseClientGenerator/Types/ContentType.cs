using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Types;

[TypeConverter(typeof(EnumDescriptionConverter))]
public enum ContentType
{
    [Description("application/json")]
    ApplicationJson,

    [Description("application/xml")]
    ApplicationXml
}