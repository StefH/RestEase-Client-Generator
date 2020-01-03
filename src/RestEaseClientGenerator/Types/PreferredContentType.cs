using RestEaseClientGenerator.Utils;
using System.ComponentModel;
using RestEaseClientGenerator.Constants;

namespace RestEaseClientGenerator.Types
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum PreferredContentType
    {
        [Description(SupportedContentTypes.ApplicationJson)]
        ApplicationJson,

        [Description(SupportedContentTypes.ApplicationXml)]
        ApplicationXml,

        //[Description(SupportedContentTypes.ApplicationFormUrlEncoded)]
        //FormUrlencoded
    }
}