using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

Generate();

Test();

// --------------------------------------------------------------

static void Generate()
{
    var generator = new Generator();

    var storageSettings = new GeneratorSettings
    {
        Namespace = "MicrosoftStorageExampleConsoleApp.MicrosoftStorage",
        ApiName = "MicrosoftStorage",
        SingleFile = false,
        PreferredMultipleResponsesType = MultipleResponsesType.AnyOf,
        PreferredSecurityDefinitionType = SecurityDefinitionType.None,
        GenerationType = GenerationType.Both
    };

    foreach (var file in generator.FromFile("MicrosoftStorage\\storage.json", storageSettings, out OpenApiDiagnostic diagnosticStorage))
    {
        Console.WriteLine("Generating file-type '{0}': {1}\\{2}", file.FileType, file.Path, file.Name);
        File.WriteAllText($"../../../MicrosoftStorage/{file.Path}/{file.Name}", file.Content);
    }
}

static void Test()
{

}