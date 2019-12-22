using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using RestEaseClientCodeGeneratorVSIX.Converters;

namespace RestEaseClientCodeGeneratorVSIX.CustomTool.AutoRest
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
