using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Types.Internal;

namespace RestEaseClientGeneratorV2.Utils;

internal static class EnumHelper
{
    public static string GetEnumClassName(GeneratorSettings settings, string name, string parentName, CasingType casing)
    {
        var enumNamePostfix = settings.PreferredEnumType == EnumType.Enum ? "EnumType" : "Constants";
        var x = $"{parentName}{name.Case(casing)}";
        return $"{x.Case(casing)}{enumNamePostfix}";
    }
}