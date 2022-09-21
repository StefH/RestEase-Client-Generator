using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Types.Internal;

namespace RestEaseClientGeneratorV2.Utils;

internal static class EnumHelper
{
    public static (string ClassName, string PostFix) GetEnumClassName(GeneratorSettings settings, string name, string parentName, CasingType casing)
    {
        var postFix = settings.PreferredEnumType == EnumType.Enum ? "EnumType" : "Constants";
        var className = $"{parentName}{name.Case(casing)}";

        return ($"{className.Case(casing)}", postFix);
    }
}