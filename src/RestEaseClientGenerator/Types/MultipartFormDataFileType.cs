using System.ComponentModel;

namespace RestEaseClientGenerator.Types
{
    /// <summary>
    /// MultipartFormData : 'file' type to generate
    /// </summary>
    public enum MultipartFormDataFileType
    {
        [Description("byte[]")]
        ByteArray,

        [Description("Stream")]
        Stream
    }
}