using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Shell;

namespace RestEaseClientGenerator.VSIX.Options.RestEase
{
    [ExcludeFromCodeCoverage]
    public class RestEaseOptionsPage : DialogPage, IRestEaseOptions
    {
        public const string Name = "Settings";

        [Category(Name)]
        [DisplayName("TODO")]
        [Description("TODO...")]
        public bool TODO { get; set; }
    }
}