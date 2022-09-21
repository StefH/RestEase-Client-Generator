using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGeneratorV2;

var generator = new GeneratorV2();

//var settingsStableDiffusionModel = new GeneratorSettings
//{
//    SingleFile = false,
//    Namespace = "ConsoleAppV2.Examples.Replicate",
//    ApiName = "StableDiffusion"
//};
//foreach (var file in generator.Map(settingsStableDiffusionModel, @"Examples\Replicate\stable.json", out var stableDiag))
//{
//    File.WriteAllText($"../../../../ConsoleAppV2/Examples/Replicate/{file.Path}/{file.Name}", file.Content);
//}

//var settings = new GeneratorSettings
//{
//    SingleFile = false,
//    Namespace = "ConsoleAppV2.Examples.Pitane",
//    ApiName = "Pitane",
//};
//foreach (var file in generator.Map(settings, @"Examples\Pitane\Pitane.json", out var pitaneDiag))
//{
//    File.WriteAllText($"../../../../ConsoleAppV2/Examples/Pitane/{file.Path}/{file.Name}", file.Content);
//}

var storageSettings = new GeneratorSettings
{
    Namespace = "MicrosoftExampleConsoleApp.MicrosoftStorage",
    ApiName = "MicrosoftStorage",
    SingleFile = false,
    PreferredSecurityDefinitionType = SecurityDefinitionType.None,
    ConstantQueryParameters = new Dictionary<string, string> { { "api-version", "2021-04-01" } }
};

generator = new GeneratorV2();
const string x = @"C:\Dev\azure-rest-api-specs\specification\storage\resource-manager\Microsoft.Storage\stable\2021-04-01\storage.json";
foreach (var file in Directory.GetFiles("../../../MicrosoftStorage/Models", "*.cs"))
{
    //File.Delete(file);
}
foreach (var file in generator.Map(storageSettings, x, out OpenApiDiagnostic diagnosticStorage))
{
    Console.WriteLine("Generating file-type '{0}': {1}\\{2}", file.FileType, file.Path, file.Name);
    File.WriteAllText($"../../../MicrosoftStorage/{file.Path}/{file.Name}", file.Content);
}