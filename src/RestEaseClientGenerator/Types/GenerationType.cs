using System;
using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Types
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    [Flags]
    public enum GenerationType
    {
        [Description("Api")]
        Api = 1,

        [Description("Models")]
        Models = 2,

        [Description("Api and Models")]
        Both = 3
    }
}