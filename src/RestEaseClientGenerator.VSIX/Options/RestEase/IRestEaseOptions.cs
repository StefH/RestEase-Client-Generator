using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.VSIX.Options.RestEase
{
    public interface IRestEaseOptions
    {
        ArrayType ArrayType { get; set; }

        bool FailOnOpenApiErrors { get; set; }

        bool AddAuthorizationHeader { get; set; }

        bool UseDateTimeOffset { get; set; }

        MethodReturnType MethodReturnType { get; set; }

        bool AppendAsync { get; set; }
    }
}