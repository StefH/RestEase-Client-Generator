// ReSharper disable All

using System.ComponentModel;
using OpenApi.RestEase.Generator.Utils;

namespace RestEaseClientGenerator.Types;

[TypeConverter(typeof(EnumDescriptionConverter))]
public enum ArrayType
{
    [Description("T[]")]
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