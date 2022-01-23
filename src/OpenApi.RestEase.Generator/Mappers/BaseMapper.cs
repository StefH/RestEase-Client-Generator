using OpenApi.RestEase.Generator.Extensions;
using OpenApi.RestEase.Generator.Settings;
using OpenApi.RestEase.Generator.Types;
using RestEaseClientGenerator.Types;

namespace OpenApi.RestEase.Generator.Mappers;

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

    protected string MakeValidReferenceId(string id)
    {
        return MakeValidModelName(id.Split('/').Last());
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