using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Builders
{
    public abstract class BaseBuilder
    {
        protected readonly GeneratorSettings Settings;

        protected BaseBuilder(GeneratorSettings settings)
        {
            Settings = settings;
        }

        protected string BuildModelsNamespace(string input)
        {
            if (string.IsNullOrEmpty(Settings.ModelsNamespace))
            {
                return input;
            }

            if (Settings.ModelsNamespaceType == ModelNamespaceType.Append)
            {
                return $"{input}.{Settings.ModelsNamespace}";
            }

            return Settings.ModelsNamespace;
        }

        protected string BuildApiNamespace(string input)
        {
            if (string.IsNullOrEmpty(Settings.ApiNamespace))
            {
                return input;
            }

            if (Settings.ApiNamespaceType == ModelNamespaceType.Append)
            {
                return $"{input}.{Settings.ApiNamespace}";
            }

            return Settings.ApiNamespace;
        }
    }
}
