using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Types
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum ModelNamespaceType
    {
        [Description("Append")]
        Append,

        [Description("Define")]
        Define
    }
}