using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.VSIX.Options.RestEase
{
    public interface IRestEaseOptions
    {
        ArrayType ArrayType { get; set; }

        MultipartFormDataFileType MultipartFormDataFileType { get; set; }

        ApplicationOctetStreamType ApplicationOctetStreamType { get; set; }

        bool FailOnOpenApiErrors { get; set; }

        bool AddAuthorizationHeader { get; set; }

        bool UseDateTimeOffset { get; set; }

        MethodReturnType MethodReturnType { get; set; }

        bool AppendAsync { get; set; }

        bool GenerateMultipartFormDataExtensionMethods { get; set; }

        bool GenerateApplicationOctetStreamExtensionMethods { get; set; }

        bool GenerateFormUrlEncodedExtensionMethods { get; set; }

        string ApiNamespace { get; set; }

        string ModelsNamespace { get; set; }

        bool ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified { get; set; }
    }
}