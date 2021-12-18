using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.VSIX.Options.RestEase
{
    public interface IRestEaseOptions
    {
        ArrayType ArrayType { get; set; }

        MultipartFormDataFileType MultipartFormDataFileType { get; set; }

        ApplicationOctetStreamType ApplicationOctetStreamType { get; set; }

        bool FailOnOpenApiErrors { get; set; }

        bool UseDateTimeOffset { get; set; }

        MethodReturnType MethodReturnType { get; set; }

        bool AppendAsync { get; set; }

        bool GenerateMultipartFormDataExtensionMethods { get; set; }

        bool GenerateApplicationOctetStreamExtensionMethods { get; set; }

        bool GenerateFormUrlEncodedExtensionMethods { get; set; }

        string ApiNamespace { get; set; }

        string ModelsNamespace { get; set; }

        bool ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified { get; set; }

        ContentType PreferredContentType { get; set; }

        bool ForceContentTypeToApplicationJson { get; set; }

        bool UseOperationIdAsMethodName { get; set; }

        SecurityDefinitionType PreferredSecurityDefinitionType { get; set; }

        bool UseUserOptions { get; set; }

        bool MakeNonRequiredParametersOptional { get; set; }

        bool GeneratePrimitivePropertiesAsNullableForOpenApi20 { get; set; }

        bool SupportExtensionXNullable { get; set; }

        bool DefineAllMethodHeadersOnInterface { get; set; }

        bool UpdateUserOptionsWithNewOptions { get; set; }

        bool DefineSharedMethodQueryParametersOnInterface { get; set; }

        GenerationType GenerationType { get; set; }

        bool GenerateAndUseModelForAnyOfOrOneOf { get; set; }

        EnumType PreferredEnumType { get; set; }

        MultipleResponsesType PreferredMultipleResponsesType { get; set; }
    }
}