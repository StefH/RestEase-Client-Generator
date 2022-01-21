using RestEaseClientGenerator.Settings;

namespace RestEaseClientGenerator.Builders;

public abstract class BaseBuilder
{
    protected readonly GeneratorSettings Settings;

    protected BaseBuilder(GeneratorSettings settings)
    {
        Settings = settings;
    }

    protected string AppendModelsNamespace(string input)
    {
        if (string.IsNullOrEmpty(Settings.ModelsNamespace))
        {
            return input;
        }

        return $"{input}.{Settings.ModelsNamespace}";
    }

    protected string AppendApiNamespace(string input)
    {
        if (string.IsNullOrEmpty(Settings.ApiNamespace))
        {
            return input;
        }

        return $"{input}.{Settings.ApiNamespace}";
    }
}