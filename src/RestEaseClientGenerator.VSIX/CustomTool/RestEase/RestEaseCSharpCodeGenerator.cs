using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TextTemplating.VSHost;

namespace RestEaseClientGenerator.VSIX.CustomTool.RestEase
{
    [ExcludeFromCodeCoverage]
    [Guid("A2AE3194-DD0B-44FC-B8C4-B40EB2BF6498")]
    [ComVisible(true)]
    [ProvideObject(typeof(RestEaseCSharpCodeGenerator))]
    [CodeGeneratorRegistration(typeof(RestEaseCSharpCodeGenerator),
                              Description,
                              ProvideCodeGeneratorAttribute.CSharpProjectGuid,
                              GeneratesDesignTimeSource = true,
                              GeneratorRegKeyName = "RestEaseCodeGenerator")]
    public class RestEaseCSharpCodeGenerator : RestEaseCodeGenerator
    {
        public const string Description = "RestEase Client Code Generator";

        public override int DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = ".cs";
            return 0;
        }
    }
}