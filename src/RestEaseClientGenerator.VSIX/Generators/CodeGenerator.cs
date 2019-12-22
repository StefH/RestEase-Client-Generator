using System;
using System.IO;
using RestEaseClientGenerator;

namespace RestEaseClientCodeGeneratorVSIX.Generators
{
    public abstract class CodeGenerator : ICodeGenerator
    {
        protected readonly string DefaultNamespace;
        protected readonly string SwaggerFile;
        private readonly IProcessLauncher _processLauncher;
        private readonly IGenerator _generator = new Generator();

        protected CodeGenerator(string swaggerFile, string defaultNamespace, IProcessLauncher processLauncher)
        {
            SwaggerFile = swaggerFile ?? throw new ArgumentNullException(nameof(swaggerFile));
            DefaultNamespace = defaultNamespace ?? throw new ArgumentNullException(nameof(defaultNamespace));
            _processLauncher = processLauncher ?? throw new ArgumentNullException(nameof(processLauncher));
        }

        public virtual string GenerateCode(IProgressReporter pGenerateProgress)
        {
            try
            {
                pGenerateProgress.Progress(10);

                string name = Path.GetFileNameWithoutExtension(SwaggerFile);
                string path = Path.GetDirectoryName(SwaggerFile);

                var result = _generator.FromStream(File.OpenRead(path), DefaultNamespace, name, out var diag);

                var outputFile = Path.Combine(
                    path ?? throw new InvalidOperationException(),
                    $"{Guid.NewGuid()}.cs");

                var command = GetCommand();
                var arguments = GetArguments(outputFile);
                pGenerateProgress.Progress(30);

                _processLauncher.Start(command, arguments);
                pGenerateProgress.Progress(80);

                return FileHelper.ReadThenDelete(outputFile);
            }
            finally
            {
                pGenerateProgress.Progress(90);
            }
        }

        protected abstract string GetArguments(string outputFile);
        protected abstract string GetCommand();
    }
}