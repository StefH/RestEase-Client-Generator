// ReSharper disable All
using RestEaseClientGenerator.VSIX.Utils;
using System.ComponentModel;

namespace RestEaseClientGenerator.VSIX.Types
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum ArrayTypeProperty
    {
        [Description("[]")]
        Array,

        [Description("IEnumerable<T>")]
        IEnumerable,

        [Description("IList<T>")]
        IList,

        [Description("ICollection<T>")]
        ICollection,

        [Description("List<T>")]
        List
    }
}