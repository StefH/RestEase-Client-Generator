using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
                var options = _optionsFactory.Create<IRestEaseOptions, RestEaseOptionsPage>();

                pGenerateProgress.Progress(5);

                string apiName = Path.GetFileNameWithoutExtension(wszInputFilePath);

                Trace.WriteLine("Generating interface and models");
                var settings = new GeneratorSettings
                {
                    Namespace = wszDefaultNamespace,
                    ApiName = apiName,
                    ArrayType = options.ArrayType
                };
                var result = _generator.FromStream(File.OpenRead(wszInputFilePath), settings, out var diagnostic);

                if (diagnostic.Errors.Any() || !result.Any())
                {
                    var errorMessages = string.Join(" | ", diagnostic.Errors.Select(e => e.Message));
                    Trace.WriteLine($"OpenApiDiagnostic errors: {errorMessages}");

                    pcbOutput = 0;
                    return 1;
                }

                pGenerateProgress.Progress(90);
                string allCode = string.Join("\r\n", result.Select(x => x.Content));

                rgbOutputFileContents[0] = allCode.ConvertToIntPtr(out pcbOutput);
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