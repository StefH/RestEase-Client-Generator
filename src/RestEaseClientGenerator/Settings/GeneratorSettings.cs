using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Settings
{
    public class GeneratorSettings
    {
        public bool SingleFile { get; set; }

        #region General
        public ArrayType ArrayType { get; set; }

        public MultipartFormDataFileType MultipartFormDataFileType { get; set; }

        public string Namespace { get; set; }

        public bool UseDateTimeOffset { get; set; }

        public bool GenerateMultipartFormDataExtensionMethods { get; set; } = true;
        #endregion

        #region Interface
        public string ApiName { get; set; }

        public bool AddAuthorizationHeader { get; set; }

        public MethodReturnType MethodReturnType { get; set; }

        public bool AppendAsync { get; set; } = true;
        #endregion
    }
}