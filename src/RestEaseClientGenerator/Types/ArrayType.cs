using System.ComponentModel;

namespace RestEaseClientGenerator.Types
{
    // [TypeConverter(typeof(RestEaseClientGenerator.VSIX.Extensions.))]

    public enum ArrayType
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