using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Settings
{
    public class GeneratorSettings
    {
        public static GeneratorSettings Default = new GeneratorSettings();


        public ArrayType ArrayType { get; set; }

        public string Namespace { get; set; }

        public string ApiName { get; set; }
    }
}