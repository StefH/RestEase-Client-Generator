using System.ComponentModel;
using OpenApi.RestEase.Generator.Utils;

namespace OpenApi.RestEase.Generator.Types;

/// <summary>
/// ApplicationOctet : 'content' type to generate
/// </summary>
[TypeConverter(typeof(EnumDescriptionConverter))]
public enum ApplicationOctetStreamType
{
    [Description("byte[]")]
    ByteArray,

    [Description("Stream")]
    Stream
}