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
                            var restEaseUserOptions = _optionsFactory.Deserialize(File.ReadAllText(optionsPath));
                            options.MergeWith(restEaseUserOptions);
                        }
                        catch
                        {
                            Trace.WriteLine($"Unable to read custom settings file '{optionsPath}'.");
                        }

                        try
                        {
                            string json = _optionsFactory.Serialize(options);
                            File.WriteAllText(optionsPath, json);
                        }
                        catch
                        {
                            Trace.WriteLine($"Unable to update custom settings file '{optionsPath}'.");
                        }
                    }
                }

                Trace.WriteLine("Generating Interface and Models");
                var settings = TinyMapperUtils.Instance.Map<GeneratorSettings>(options);
                settings.SingleFile = true;
                settings.Namespace = wszDefaultNamespace;
                settings.ApiName = apiName;

                var result = _generator.FromFile(wszInputFilePath, settings, out var diagnostic);

                if (options.FailOnOpenApiErrors && diagnostic.Errors.Any())
                {
                    var errorMessages = string.Join(" | ", diagnostic.Errors.Select(JsonConvert.SerializeObject));
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
                return (RestEaseOptionsPage)_optionsFactory.Create<RestEaseOptionsPage>();
            }
            catch
            {
                Trace.WriteLine($"Error getting {nameof(RestEaseOptionsPage)} using default.");
                return new RestEaseOptionsPage();
            }
        }
    }
}