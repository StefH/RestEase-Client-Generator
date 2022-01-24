using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Types;

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