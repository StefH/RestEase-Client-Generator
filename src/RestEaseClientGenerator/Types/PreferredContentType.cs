using RestEaseClientGenerator.Utils;
using System.ComponentModel;

namespace RestEaseClientGenerator.Types
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum PreferredContentType
    {
        [Description("application/json")]
        ApplicationJson,

        [Description("application/xml")]
        ApplicationXml,

        //[Description("")]
        //FormUrlencoded
    }
}