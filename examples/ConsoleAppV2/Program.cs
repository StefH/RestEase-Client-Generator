using RestEaseClientGenerator.Settings;
using RestEaseClientGeneratorV2;

var generatorV2 = new GeneratorV2();

var settings = new GeneratorSettings
{
    SingleFile = true,
    Namespace = "ConsoleAppV2.Examples.Pitane",
    ApiName = "Pitane",
};
foreach (var file in generatorV2.Map(settings, @"Examples\Pitane\Pitane.json", out var pitaneDiag))
{
    File.WriteAllText($"../../../../ConsoleAppV2/Examples/Pitane/{file.Path}/{file.Name}", file.Content);
}