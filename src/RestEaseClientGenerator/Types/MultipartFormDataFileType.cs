using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Types
{
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
}