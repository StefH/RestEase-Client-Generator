namespace RestEaseClientGeneratorV2.Extensions;

internal static class TypeExtensions
{
    private static readonly Dictionary<Type, string> TypeMapping = new()
    {
        { typeof(int), "int" },
        { typeof(uint), "uint" },
        { typeof(long), "long" },
        { typeof(ulong), "ulong" },
        { typeof(short), "short" },
        { typeof(ushort), "ushort" },
        { typeof(byte), "byte" },
        { typeof(sbyte), "sbyte" },
        { typeof(bool), "bool" },
        { typeof(float), "float" },
        { typeof(double), "double" },
        { typeof(decimal), "decimal" },
        { typeof(char), "char" },
        { typeof(string), "string" },
        { typeof(object), "object" },
        { typeof(void), "void"}
    };

    /// <summary>
    /// https://stackoverflow.com/questions/16466380/get-user-friendly-name-for-generic-type-in-c-sharp
    /// </summary>
    public static string GetFriendlyName(this Type type)
    {
        if (TypeMapping.TryGetValue(type, out var value))
        {
            return value;
        }

        return type.IsGenericType ?
            $"{type.Name.Split('`')[0]}<{string.Join(", ", type.GetGenericArguments().Select(GetFriendlyName).ToArray())}>" :
            type.Name;
    }
}