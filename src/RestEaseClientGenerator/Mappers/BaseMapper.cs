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

    protected string MakeValidClassName(string name)
    {
        return name.Replace(" ", "").Split('.').Last().ToPascalCase();
    }

    protected string MakeValidReferenceId(string id)
    {
        return MakeValidClassName(id.Split('/').Last());
    }
}