using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Shell;

namespace RestEaseClientCodeGeneratorVSIX.Options.RestEase
{
    [ExcludeFromCodeCoverage]
    public class RestEaseOptionsPage : DialogPage, IRestEaseOptions
    {
        public const string Name = "AutoRest";

        [Category(Name)]
        [DisplayName("Add Credentials")]
        [Description("Include a credential property and constructor parameter supporting different authentication behaviors")]
        public bool AddCredentials { get; set; }

        [Category(Name)]
        [DisplayName("Override Client Name")]
        [Description("Overrides the name of the client class (usually derived from $.info.title) and use the document filename instead")]
        public bool OverrideClientName { get; set; }


        [Category(Name)]
        [DisplayName("Use Internal Constructors")]
        [Description("Generate constructors with internal instead of public visibility (useful for convenience layers)")]
        public bool UseInternalConstructors { get; set; }

        [Category(Name)]
        [DisplayName("Generate Sync Methods")]
        [Description("Determines the amount of synchronous wrappers to generate (Default: Essential)")]
        public SyncMethodOptions SyncMethods { get; set; }

        
        [Category(Name)]
        [DisplayName("Use DateTimeOffset")]
        [Description("Use DateTimeOffset instead of DateTime to model date/time types")]
        public bool UseDateTimeOffset { get; set; }


        [Category(Name)]
        [DisplayName("Client Side Validation")]
        [Description("Whether to validate parameters at the client side (according to OpenAPI definition) before making a request (Default: True)")]
        public bool ClientSideValidation { get; set; } = true;
    }
}