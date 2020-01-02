using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Settings
{
    public class GeneratorSettings
    {
        public bool SingleFile { get; set; }

        #region General
        public ArrayType ArrayType { get; set; }

        public string Namespace { get; set; }

        public bool UseDateTimeOffset { get; set; }

        public string ApiNamespace { get; set; } = "Api";

        public string ModelsNamespace { get; set; } = "Models";
        #endregion

        #region Interface
        public string ApiName { get; set; }

        public bool AddAuthorizationHeader { get; set; }

        public MethodReturnType MethodReturnType { get; set; }

        public bool AppendAsync { get; set; } = true;

        public MultipartFormDataFileType MultipartFormDataFileType { get; set; }

        public ApplicationOctetStreamType ApplicationOctetStreamType { get; set; }

        public bool GenerateMultipartFormDataExtensionMethods { get; set; } = true;

        public bool GenerateApplicationOctetStreamExtensionMethods { get; set; } = true;

        public bool GenerateFormUrlEncodedExtensionMethods { get; set; } = true;

        public bool ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified { get; set; }

        public SecurityDefinitionType SecurityDefinitionType { get; set; } = SecurityDefinitionType.Header;
        #endregion
    }
}