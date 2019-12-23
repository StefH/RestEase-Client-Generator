using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace RestEaseClientGenerator.VSIX.CustomTool.RestEase
{
    [ExcludeFromCodeCoverage]
    [ComVisible(true)]
    public abstract class RestEaseCodeGenerator : SingleFileCodeGenerator
    {
        protected RestEaseCodeGenerator() : base(SupportedCodeGenerator.RestEase)
        {
        }
    }
}