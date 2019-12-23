using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator;
using System.IO;

namespace RestEaseClientGeneratorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator();

            foreach (var file in generator.FromStream(File.OpenRead("drc.json"), "RestEaseClientGeneratorConsoleApp.Drc", "Drc", out OpenApiDiagnostic diagnosticDrc))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Drc/{file.Path}/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("petstore.yaml"), "RestEaseClientGeneratorConsoleApp.PetStore", "PetStore", out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/PetStore/{file.Path}/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("petstore.json"), "RestEaseClientGeneratorConsoleApp.PetStoreJson", "PetStoreJson", out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/PetStoreJson/{file.Path}/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("infura.yaml"), "RestEaseClientGeneratorConsoleApp.Infura", "Infura", out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Infura/{file.Path}/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("cognitive-services-personalizer.json"), "RestEaseClientGeneratorConsoleApp.Cog", "Cog", out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Cog/{file.Path}/{file.Name}", file.Content);
            }
        }
    }
}