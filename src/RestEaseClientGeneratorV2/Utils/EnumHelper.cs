using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGeneratorV2.Utils;

internal static class EnumHelper
{
    public static string GetEnumClassName(GeneratorSettings settings, string name, string parentName)
    {
        var enumNamePostfix = settings.PreferredEnumType == EnumType.Enum ? "EnumType" : "Constants";
        return $"{parentName}{name}{enumNamePostfix}".ToPascalCase();
    }
}