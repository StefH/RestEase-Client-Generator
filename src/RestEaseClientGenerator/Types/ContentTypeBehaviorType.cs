using RestEaseClientGenerator.Utils;
using System.ComponentModel;

namespace RestEaseClientGenerator.Types
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum ContentTypeBehavior
    {
        [Description("Default")]
        Default,

        [Description("Force to remove")]
        ForceRemove,

        [Description("Force to application/json")]
        ForceToApplicationJson
    }
}