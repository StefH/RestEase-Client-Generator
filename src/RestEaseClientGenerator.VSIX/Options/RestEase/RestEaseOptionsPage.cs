using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Shell;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.VSIX.Options.RestEase
{
    [ExcludeFromCodeCoverage]
    public class RestEaseOptionsPage : DialogPage, IRestEaseOptions
    {
        public const string Name = "Settings";

        [Category(Name)]
        [DisplayName("ArrayType")]
        [Description("Array type to use. The default is Array ([]).")]
        public ArrayType ArrayType { get; set; }
    }
}