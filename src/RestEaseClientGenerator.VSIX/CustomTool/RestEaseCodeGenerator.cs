using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using Newtonsoft.Json;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.VSIX.Extensions;
using RestEaseClientGenerator.VSIX.Options;
using RestEaseClientGenerator.VSIX.Options.RestEase;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RestEaseClientGenerator.VSIX.CustomTool
{
    [Guid("A2AE3194-0000-44FC-B8C4-B40EB2BF6498")]
    [ComVisible(true)]
    [ProvideObject(typeof(RestEaseCodeGenerator))]
    [CodeGeneratorRegistration(typeof(RestEaseCodeGenerator),
        "RestEase Client Code Generator",
        ProvideCodeGeneratorAttribute.CSharpProjectGuid,
        GeneratesDesignTimeSource = true,
        GeneratorRegKeyName = nameof(RestEaseCodeGenerator))]
    public class RestEaseCodeGenerator : IVsSingleFileGenerator
    {
        private readonly IOptionsFactory _optionsFactory = new OptionsFactory();

        private readonly IGenerator _generator = new Generator();

        public SupportedCodeGenerator CodeGenerator { get; } = SupportedCodeGenerator.RestEase;

        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = ".cs";
            return 0;
        }

        public int Generate(
            string wszInputFilePath,
            string bstrInputFileContents,
            string wszDefaultNamespace,
            IntPtr[] rgbOutputFileContents,
            out uint pcbOutput,
            IVsGeneratorProgress pGenerateProgress)
        {
            try
            {
                pGenerateProgress.Progress(5);

                var options = GetOptionsFromOptionsPage();

                string baseDirectory = Path.GetDirectoryName(wszInputFilePath);
                string apiName = Path.GetFileNameWithoutExtension(wszInputFilePath);
                
                if (options.UseUserOptions)
                {
                    string optionsPath = Path.Combine(baseDirectory, $"{apiName}.RestEaseOptions");

                    if (!File.Exists(optionsPath))
                    {
                        try
                        {
                            string json = _optionsFactory.Serialize(options);
                            File.WriteAllText(optionsPath, json);
                        }
                        catch
                        {
                            Trace.WriteLine($"Unable to write custom settings file '{optionsPath}'.");
                        }
                    }
                    else
                    {
                        try
                        {
                            var userSettings = JsonConvert.DeserializeObject<RestEaseUserOptions>(File.ReadAllText(optionsPath));
                            options.MergeWith(userSettings);
                        }
                        catch
                        {
                            Trace.WriteLine($"Unable to read custom settings file '{optionsPath}'.");
                        }
                    }
                }

                Trace.WriteLine("Generating Interface and Models");
                var settings = new GeneratorSettings
                {
                    SingleFile = true,
                    Namespace = wszDefaultNamespace,
                    ApiName = apiName,
                    ArrayType = options.ArrayType,
                    UseDateTimeOffset = options.UseDateTimeOffset,
                    MethodReturnType = options.MethodReturnType,
                    AppendAsync = options.AppendAsync,
                    GenerateFormUrlEncodedExtensionMethods = options.GenerateFormUrlEncodedExtensionMethods,
                    GenerateApplicationOctetStreamExtensionMethods = options.GenerateApplicationOctetStreamExtensionMethods,
                    GenerateMultipartFormDataExtensionMethods = options.GenerateMultipartFormDataExtensionMethods,
                    MultipartFormDataFileType = options.MultipartFormDataFileType,
                    ApplicationOctetStreamType = options.ApplicationOctetStreamType,
                    ApiNamespace = options.ApiNamespace,
                    ModelsNamespace = options.ModelsNamespace,
                    ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified = options.ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified,
                    PreferredContentType = options.PreferredContentType,
                    ForceContentTypeToApplicationJson = options.ForceContentTypeToApplicationJson,
                    UseOperationIdAsMethodName = options.UseOperationIdAsMethodName,
                    PreferredSecurityDefinitionType = options.PreferredSecurityDefinitionType
                };
                var result = _generator.FromStream(File.OpenRead(wszInputFilePath), settings, out var diagnostic);

                if (options.FailOnOpenApiErrors && diagnostic.Errors.Any())
                {
                    var errorMessages = string.Join(" | ", diagnostic.Errors.Select(e => JsonSerializer.Serialize(e)));
                    Trace.WriteLine($"OpenApi Errors: {errorMessages}");

                    pcbOutput = 0;
                    return 1;
                }

                pGenerateProgress.Progress(90);
                string code = result.First().Content;

                rgbOutputFileContents[0] = code.ConvertToIntPtr(out pcbOutput);
                pGenerateProgress.Progress(100);

                Trace.WriteLine("All done");
            }
            catch (Exception e)
            {
                pGenerateProgress.GeneratorError(e);
                Trace.WriteLine("Unable to generate code");
                Trace.WriteLine(e);
                throw;
            }

            return 0;
        }

        private RestEaseOptionsPage GetOptionsFromOptionsPage()
        {
            try
            {
                return (RestEaseOptionsPage) _optionsFactory.Create<RestEaseOptionsPage>();
            }
            catch
            {
                Trace.WriteLine($"Error getting {nameof(RestEaseOptionsPage)} using default.");
                return new RestEaseOptionsPage();
            }
        }
    }
}