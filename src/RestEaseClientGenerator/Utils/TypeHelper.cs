using System.Reflection;

namespace RestEaseClientGenerator.Utils;

public static class TypeHelper
{
    public static bool IsNullableType(Type type)
    {
        return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
    }

    public static Type GetNonNullableType(Type type)
    {
        return IsNullableType(type) ? type.GetTypeInfo().GetGenericArguments()[0] : type;
    }
}