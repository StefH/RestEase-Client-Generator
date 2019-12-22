using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using RestEaseClientCodeGeneratorVSIX.Converters;
using RestEaseClientCodeGeneratorVSIX.Extensions;
using RestEaseClientCodeGeneratorVSIX.Generators;

namespace RestEaseClientCodeGeneratorVSIX.CustomTool
{
    [ExcludeFromCodeCoverage]
    [ComVisible(true)]
    public abstract class SingleFileCodeGenerator : IVsSingleFileGenerator
    {
        private readonly SupportedLanguage _supportedLanguage;
        private readonly ILanguageConverter _converter;

        public SupportedCodeGenerator CodeGenerator { get; }

        protected SingleFileCodeGenerator(
            SupportedCodeGenerator supportedCodeGenerator,
            SupportedLanguage supportedLanguage = SupportedLanguage.CSharp,
            ILanguageConverter converter = null)
        {
            CodeGenerator = supportedCodeGenerator;
            _supportedLanguage = supportedLanguage;
            _converter = converter;
        }

        public abstract int DefaultExtension(out string pbstrDefaultExtension);

        public ICodeGeneratorFactory Factory { get; set; } = new CodeGeneratorFactory();

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

                var codeGenerator = Factory.Create(
                    wszDefaultNamespace,
                    bstrInputFileContents,
                    wszInputFilePath,
                    _supportedLanguage,
                    CodeGenerator);

                var code = codeGenerator.GenerateCode(new ProgressReporter(pGenerateProgress));
                if (string.IsNullOrWhiteSpace(code))
                {
                    pcbOutput = 0;
                    return 1;
                }

                if (_supportedLanguage == SupportedLanguage.VisualBasic && _converter != null)
                {
                    Trace.WriteLine(Environment.NewLine);
                    Trace.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Trace.WriteLine("!!! EXPERIMENTAL - Attempting to convert C# code to Visual Basic !!!");
                    Trace.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Trace.WriteLine(Environment.NewLine);

                    code = _converter
                        .ConvertAsync(code)
                        .GetAwaiter()
                        .GetResult();
                }

                rgbOutputFileContents[0] = code.ConvertToIntPtr(out pcbOutput);
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