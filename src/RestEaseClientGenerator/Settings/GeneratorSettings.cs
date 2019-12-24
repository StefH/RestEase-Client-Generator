using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Settings
{
    public class GeneratorSettings
    {
        public bool SingleFile { get; set; }

        public ArrayType ArrayType { get; set; }

        public string Namespace { get; set; }

        public string ApiName { get; set; }

        public bool AddAuthorizationHeader { get; set; }

        public bool UseDateTimeOffset { get; set; }
    }
}