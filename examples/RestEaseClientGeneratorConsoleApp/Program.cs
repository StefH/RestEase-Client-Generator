using System.IO;
using System.Threading.Tasks;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGeneratorConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var reader = new OpenApiStreamReader();

            var generator = new Generator();

            //var drcSettings = new GeneratorSettings
            //{
            //    Namespace = "RestEaseClientGeneratorConsoleApp.Examples.Drc",
            //    ApiName = "Drc",
            //    ForceContentTypeToApplicationJson = true,
            //    UseOperationIdAsMethodName = false
            //};
            //foreach (var file in generator.FromStream(File.OpenRead("Examples\\drc.json"), drcSettings, out var diagnosticFormRecognizer))
            //{
            //    File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/Drc/{file.Path}/{file.Name}", file.Content);
            //}

            var sharedQueryParamsWithExtensionMethodSettings = new GeneratorSettings
            {
                SingleFile = false,
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.SharedQuery",
                ApiName = "SharedQuery",
                GenerateFormUrlEncodedExtensionMethods = true,
                GenerateMultipartFormDataExtensionMethods = true,
                GenerateApplicationOctetStreamExtensionMethods = true
            };
            foreach (var file in generator.FromStream(File.OpenRead("Examples\\SharedQueryParamsWithExtensionMethod.json"), sharedQueryParamsWithExtensionMethodSettings, out OpenApiDiagnostic sharedDiag))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/SharedQuery/{file.Path}/{file.Name}", file.Content);
            }

            var petStoreOpenApi3Settings = new GeneratorSettings
            {
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi302",
                ApiName = "PetStoreOpenApi3",
                GenerateFormUrlEncodedExtensionMethods = true,
                GenerateMultipartFormDataExtensionMethods = true,
                GenerateApplicationOctetStreamExtensionMethods = true,
                ApplicationOctetStreamType = ApplicationOctetStreamType.ByteArray,
                PreferredContentType = ContentType.ApplicationJson,
                DefineAllMethodHeadersOnInterface = true,
                MethodReturnType = MethodReturnType.Type
            };
            foreach (var file in generator.FromStream(File.OpenRead("Examples\\petstore-openapi3.json"), petStoreOpenApi3Settings, out OpenApiDiagnostic diagnosticPetStoreOpenApi3))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/PetStoreOpenApi302/{file.Path}/{file.Name}", file.Content);
            }

            var petStoreSettings = new GeneratorSettings
            {
                ArrayType = ArrayType.ICollection,
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.PetStore",
                ApiName = "PetStore",
                SupportExtensionXNullable = true,
                ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified = true
            };
            foreach (var file in generator.FromStream(File.OpenRead("Examples\\petstore.yaml"), petStoreSettings, out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/PetStore/{file.Path}/{file.Name}", file.Content);
            }

            var petStoreJsonSettings = new GeneratorSettings
            {
                SingleFile = true,
                ArrayType = ArrayType.IEnumerable,
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson",
                ApiName = "PetStoreJson",
                UseDateTimeOffset = true,
                MethodReturnType = MethodReturnType.Type,
                MultipartFormDataFileType = MultipartFormDataFileType.Stream,
                ApiNamespace = "Test123",
                ModelsNamespace = "Modelz"
            };
            foreach (var file in generator.FromStream(File.OpenRead("Examples\\petstore.json"), petStoreJsonSettings, out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/PetStoreJson/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("Examples\\infura.yaml"), "RestEaseClientGeneratorConsoleApp.Examples.Infura", "Infura", false, out OpenApiDiagnostic diagnosticInfura))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/Infura/{file.Path}/{file.Name}", file.Content);
            }

            var cogSettings = new GeneratorSettings
            {
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.Cog",
                ApiName = "Cog",
                ForceContentTypeToApplicationJson = true
            };

            foreach (var file in generator.FromStream(File.OpenRead("Examples\\cognitive-services-personalizer.json"), cogSettings, out var diagnosticCog))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/Cog/{file.Path}/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("Examples\\SpeechServices.json"), "RestEaseClientGeneratorConsoleApp.Examples.SpeechServices", "SpeechServices", false, out var diagnosticSpeech))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/SpeechServices/{file.Path}/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("Examples\\FormRecognizer.json"), "RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer", "FormRecognizer", false, out var diagnosticFormRecognizer))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/FormRecognizer/{file.Path}/{file.Name}", file.Content);
            }

            var formSettings = new GeneratorSettings
            {
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2",
                ApiName = "FormRecognizerV2",
                SupportExtensionXNullable = true,
                PreferredSecurityDefinitionType = SecurityDefinitionType.Query
            };
            foreach (var file in generator.FromStream(File.OpenRead("Examples\\FormRecognizerV2.json"), formSettings, out var diagnosticFormRecognizerV2))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/FormRecognizerV2/{file.Path}/{file.Name}", file.Content);
            }

            var computerVisionSettings = new GeneratorSettings
            {
                SingleFile = true,
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.ComputerVision",
                ApiName = "ComputerVision"
            };
            foreach (var file in generator.FromStream(File.OpenRead("Examples\\ComputerVision.json"), computerVisionSettings, out var diagnosticComputerVision))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/ComputerVision/{file.Path}/{file.Name}", file.Content);
            }

            // https://medium.com/raml-api/oas-raml-converter-quick-start-3a20664fa94a
            //foreach (var file in generator.FromStream(File.OpenRead("Examples\\helloworld.raml"), "RestEaseClientGeneratorConsoleApp.Examples.HelloWorldRaml", "HelloWorldRaml", false, out var diagnosticFormRecognizer))
            //{
            //    File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/HelloWorldRaml/{file.Path}/{file.Name}", file.Content);
            //}

            await PetStoreTests.Run();

            await PetStoreOpenApi3ApiTests.Run();
        }
    }
}