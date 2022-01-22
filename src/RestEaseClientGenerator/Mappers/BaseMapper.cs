using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Mappers;

public abstract class BaseMapper
{
    protected string DateTime => Settings.UseDateTimeOffset ? "DateTimeOffset" : "DateTime";

    protected readonly GeneratorSettings Settings;

    protected BaseMapper(GeneratorSettings settings)
    {
        Settings = settings;
    }

    protected string MakeValidModelName(string name)
    {
        string last = name.Replace(" ", "").Split('.').Last();

        return last.ToValidIdentifier(CasingType.Pascal);
    }

    protected string MapArrayType(object? type)
    {
        switch (Settings.ArrayType)
        {
            case ArrayType.IEnumerable:
                return $"IEnumerable<{type}>";

            case ArrayType.ICollection:
                return $"ICollection<{type}>";

            case ArrayType.IList:
                return $"IList<{type}>";

            case ArrayType.List:
                return $"List<{type}>";

            default:
                return $"{type}[]";
        }
    }
}