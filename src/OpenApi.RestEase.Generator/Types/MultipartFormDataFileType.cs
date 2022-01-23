using System.ComponentModel;
using OpenApi.RestEase.Generator.Utils;

namespace OpenApi.RestEase.Generator.Types;

/// <summary>
/// MultipartFormData : 'file' type to generate
/// </summary>
[TypeConverter(typeof(EnumDescriptionConverter))]
public enum MultipartFormDataFileType
{
    [Description("byte[]")]
    ByteArray,

    [Description("Stream")]
    Stream
}