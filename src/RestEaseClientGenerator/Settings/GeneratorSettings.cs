using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Settings
{
    public class GeneratorSettings
    {
        public bool SingleFile { get; set; }

        #region General
        public ArrayType ArrayType { get; set; } = ArrayType.Array;

        public string Namespace { get; set; }

        public bool UseDateTimeOffset { get; set; }

        public string ApiNamespace { get; set; } = "Api";

        public string ModelsNamespace { get; set; } = "Models";

        public GenerationType GenerationType { get; set; } = GenerationType.Both;
        #endregion

        #region Models
        public bool GeneratePrimitivePropertiesAsNullableForOpenApi20 { get; set; } = false;

        public bool SupportExtensionXNullable { get; set; } = false;
        #endregion

        #region Interface
        public string ApiName { get; set; }

        // public bool AddAuthorizationHeader { get; set; }

        public MethodReturnType MethodReturnType { get; set; } = MethodReturnType.Type;

        public bool AppendAsync { get; set; } = true;

        public MultipartFormDataFileType MultipartFormDataFileType { get; set; } = MultipartFormDataFileType.ByteArray;

        public ApplicationOctetStreamType ApplicationOctetStreamType { get; set; } = ApplicationOctetStreamType.ByteArray;

        public bool GenerateMultipartFormDataExtensionMethods { get; set; } = true;

        public bool GenerateApplicationOctetStreamExtensionMethods { get; set; } = true;

        public bool GenerateFormUrlEncodedExtensionMethods { get; set; } = true;

        public bool ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified { get; set; }

        public ContentType PreferredContentType { get; set; } = ContentType.ApplicationJson;

        public bool ForceContentTypeToApplicationJson { get; set; }

        public bool UseOperationIdAsMethodName { get; set; } = true;

        public SecurityDefinitionType PreferredSecurityDefinitionType { get; set; } = SecurityDefinitionType.Automatic;

        public bool MakeNonRequiredParametersOptional { get; set; } = true;

        public bool DefineAllMethodHeadersOnInterface { get; set; } = false;

        public bool DefineSharedMethodQueryParametersOnInterface { get; set; } = true;
        #endregion
    }
}