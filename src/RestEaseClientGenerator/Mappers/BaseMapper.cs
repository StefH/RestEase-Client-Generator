using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Mappers;

public abstract class BaseMapper
{
    protected string DateTime => Settings.UseDateTimeOffset ? "DateTimeOffset" : "DateTime";

    protected readonly GeneratorSettings Settings;

    protected BaseMapper(GeneratorSettings settings)
    {
        Settings = settings;
    }

    protected string MakeValidClassName(string name)
    {
        string last = name.Replace(" ", "").Split('.').Last().ToPascalCase();

        return last; //IdentifierUtils.TryGenerateValidClassName(last, out var valid) ? valid : last; //last.ToValidIdentifier(CasingType.Pascal);
    }

    protected string MakeValidReferenceId(string id)
    {
        return MakeValidClassName(id.Split('/').Last());
    }

    protected string MapArrayType(object? type)
    {
        return Settings.ArrayType switch
        {
            ArrayType.IEnumerable => $"IEnumerable<{type}>",
            ArrayType.ICollection => $"ICollection<{type}>",
            ArrayType.IList => $"IList<{type}>",
            ArrayType.List => $"List<{type}>",
            _ => $"{type}[]"
        };
    }
}