using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using Microsoft.VisualStudio.Shell.Interop;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.VSIX.Extensions;
using RestEaseClientGenerator.VSIX.Options;
using RestEaseClientGenerator.VSIX.Options.RestEase;

namespace RestEaseClientGenerator.VSIX.CustomTool
{
    [ExcludeFromCodeCoverage]
    [ComVisible(true)]
    public abstract class SingleFileCodeGenerator : IVsSingleFileGenerator
    {
        public SupportedCodeGenerator CodeGenerator { get; }

        protected SingleFileCodeGenerator(SupportedCodeGenerator supportedCodeGenerator)
        {
            CodeGenerator = supportedCodeGenerator;
        }

        public abstract int DefaultExtension(out string pbstrDefaultExtension);

        private readonly IOptionsFactory _optionsFactory = new OptionsFactory();

        private readonly IGenerator _generator = new Generator();

        private IRestEaseOptions GetOptions()
        {
            try
            {
                return _optionsFactory.Create<IRestEaseOptions, RestEaseOptionsPage>();
            }
            catch
            {
                Trace.WriteLine($"Error getting {nameof(RestEaseOptionsPage)} using default.");
                return new RestEaseOptionsPage();
            }
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
                var options = GetOptions();

                pGenerateProgress.Progress(5);

                string apiName = Path.GetFileNameWithoutExtension(wszInputFilePath);

                Trace.WriteLine("Generating interface and models");
                var settings = new GeneratorSettings
                {
                    SingleFile = true,
                    Namespace = wszDefaultNamespace,
                    ApiName = apiName,
                    ArrayType = options.ArrayType,
                    AddAuthorizationHeader = options.AddAuthorizationHeader
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
    }
}