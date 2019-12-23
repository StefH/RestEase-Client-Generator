using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using RestEaseClientGenerator.VSIX.Extensions;

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

        private readonly IGenerator generator = new Generator();

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

                string apiName = Path.GetFileNameWithoutExtension(wszInputFilePath);
                var result = generator.FromStream(File.OpenRead(wszInputFilePath), wszDefaultNamespace, apiName, out var diagnostic);

                if (diagnostic.Errors.Any() || !result.Any())
                {
                    var errorMessages = string.Join(",", diagnostic.Errors.Select(e => e.Message));
                    Trace.WriteLine($"OpenApiDiagnostic errors: {errorMessages}");

                    pcbOutput = 0;
                    return 1;
                }

                pGenerateProgress.Progress(90);
                string allCode = string.Join("\r\n", result.Select(x => x.Content));

                rgbOutputFileContents[0] = allCode.ConvertToIntPtr(out pcbOutput);
                pGenerateProgress.Progress(100);
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