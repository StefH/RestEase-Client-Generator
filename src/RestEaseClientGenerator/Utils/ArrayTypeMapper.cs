using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Utils;

internal static class ArrayTypeMapper
{
    public static string Map(ArrayType arrayType, string type)
    {
        return arrayType switch
        {
            ArrayType.IEnumerable => $"IEnumerable<{type}>",
            ArrayType.ICollection => $"ICollection<{type}>",
            ArrayType.IList => $"IList<{type}>",
            ArrayType.List => $"List<{type}>",
            _ => $"{type}[]"
        };
    }
}