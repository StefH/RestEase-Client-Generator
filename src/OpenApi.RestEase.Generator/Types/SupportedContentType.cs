using System.ComponentModel;

namespace RestEaseClientGenerator.Types;

public enum SupportedContentType
{
    [Description("application/json")]
    ApplicationJson,

    [Description("application/xml")]
    ApplicationXml,

    [Description("application/x-www-form-urlencoded")]
    ApplicationFormUrlEncoded,

    [Description("application/octet-stream")]
    ApplicationOctetStream,

    [Description("multipart/form-data")]
    MultipartFormData
}