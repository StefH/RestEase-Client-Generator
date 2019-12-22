using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using RestEaseClientGenerator.VSIX.Converters;

namespace RestEaseClientGenerator.VSIX.CustomTool.RestEase
{
    [ExcludeFromCodeCoverage]
    [ComVisible(true)]
    public abstract class RestEaseCodeGenerator : SingleFileCodeGenerator
    {
        protected RestEaseCodeGenerator(SupportedLanguage language, ILanguageConverter languageConverter = null)
            : base(SupportedCodeGenerator.RestEase, language, languageConverter)
        {
        }
    }
}
