using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.VSIX.Options.RestEase
{
    public interface IRestEaseOptions
    {
        ArrayType ArrayType { get; set; }

        bool FailOnOpenApiErrors { get; set; }
    }
}