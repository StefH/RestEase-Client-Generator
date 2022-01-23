using System.ComponentModel;
using OpenApi.RestEase.Generator.Utils;

namespace OpenApi.RestEase.Generator.Types;

[TypeConverter(typeof(EnumDescriptionConverter))]
public enum ContentType
{
    [Description("application/json")]
    ApplicationJson,

    [Description("application/xml")]
    ApplicationXml
}