using System;
using RestEaseClientCodeGeneratorVSIX.Generators.RestEase;
using RestEaseClientCodeGeneratorVSIX.Options;
using RestEaseClientCodeGeneratorVSIX.Options.RestEase;

namespace RestEaseClientCodeGeneratorVSIX.Generators
{
    public class CodeGeneratorFactory : ICodeGeneratorFactory
    {
        private readonly IProcessLauncher _processLauncher;
        private readonly IOptionsFactory _optionsFactory;

        public CodeGeneratorFactory(IOptionsFactory optionsFactory = null, IProcessLauncher processLauncher = null)
        {
            _optionsFactory = optionsFactory ?? new OptionsFactory();
            _processLauncher = processLauncher ?? new ProcessLauncher();
        }

        public ICodeGenerator Create(
            string defaultNamespace,
            string inputFileContents,
            string inputFilePath,
            SupportedLanguage language,
            SupportedCodeGenerator generator)
        {
            switch (generator)
            {
                case SupportedCodeGenerator.RestEase:
                    return new RestEaseCSharpCodeGenerator(
                        inputFilePath,
                        defaultNamespace,
                        _optionsFactory.Create<IRestEaseOptions, RestEaseOptionsPage>(),
                        _processLauncher);                

                default:
                    throw new NotSupportedException();
            }
        }
    }
}