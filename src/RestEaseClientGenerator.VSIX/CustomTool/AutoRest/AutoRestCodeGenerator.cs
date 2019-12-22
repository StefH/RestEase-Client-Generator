using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using RestEaseClientGenerator.VSIX.Converters;

namespace RestEaseClientGenerator.VSIX.CustomTool.AutoRest
{
    [ExcludeFromCodeCoverage]
    [ComVisible(true)]
    public abstract class AutoRestCodeGenerator : SingleFileCodeGenerator
    {
        protected AutoRestCodeGenerator(SupportedLanguage language, ILanguageConverter languageConverter = null)
            : base(SupportedCodeGenerator.AutoRest, language, languageConverter)
        {
        }
    }
}
