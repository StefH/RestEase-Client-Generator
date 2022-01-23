using System.ComponentModel;
using OpenApi.RestEase.Generator.Utils;

namespace OpenApi.RestEase.Generator.Types;

[TypeConverter(typeof(EnumDescriptionConverter))]
[Flags]
public enum FileType
{
    [Description("Api")]
    Api = 1,

    [Description("ApiExtensions")]
    ApiExtensions = 2,

    [Description("Model")]
    Model = 3,

    [Description("Api and Models")]
    ApiAndModels = 4
}