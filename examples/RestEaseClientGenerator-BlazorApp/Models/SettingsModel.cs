using System.ComponentModel;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGeneratorBlazorApp.Models
{
    public class SettingsModel : GeneratorSettings
    {
        [DisplayName("Source")]
        [Description("The source. The default is 'Url'.")]
        public SourceType Source { get; set; } = SourceType.Url;

        [DisplayName("Url")]
        [Description("The OpenAPI Specification Url")]
        public string SourceUrl { get; set; } = "https://petstore.swagger.io/v2/swagger.json";

        public string FileName { get; set; } = string.Empty;

        public string? Content { get; set; }
    }
}