using System;
using RestEaseClientGenerator.VSIX.Generators.AutoRest;
using RestEaseClientGenerator.VSIX.Options;
using RestEaseClientGenerator.VSIX.Options.AutoRest;

namespace RestEaseClientGenerator.VSIX.Generators
{
    public class CodeGeneratorFactory : ICodeGeneratorFactory
    {
        private readonly IProcessLauncher processLauncher;
        private readonly IOptionsFactory optionsFactory;

        public CodeGeneratorFactory(IOptionsFactory optionsFactory = null, IProcessLauncher processLauncher = null)
        {
            this.optionsFactory = optionsFactory ?? new OptionsFactory();
            this.processLauncher = processLauncher ?? new ProcessLauncher();
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
                case SupportedCodeGenerator.AutoRest:
                    return new AutoRestCSharpCodeGenerator(
                        inputFilePath,
                        defaultNamespace,
                        optionsFactory.Create<IAutoRestOptions, AutoRestOptionsPage>(),
                        processLauncher);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}