using System;
using System.Collections.Generic;
using System.ComponentModel;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGeneratorBlazorApp.Models;

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

    [DisplayName("ConstantQueryParameters")]
    [Description("A dictionary defining values for constant query parameters.")]
    public List<DictionaryItem> ConstantQueryParameterItems { get; set; } = new() { new DictionaryItem { Id = Guid.NewGuid(), Key = "api_version", Value = "123"} };

    [DisplayName("ConstantHeaderParameter")]
    [Description("A dictionary defining values for constant header parameters.")]
    public List<DictionaryItem> ConstantHeaderParameterItems { get; set; } = new() { new DictionaryItem { Id = Guid.NewGuid(), Key = "api_key", Value = "0x0001" } };

}