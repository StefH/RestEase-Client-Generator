using System;
using System.IO;
using RestEaseClientGenerator.VSIX.Options.RestEase;
using RestEaseClientGenerator.VSIX.Options.General;

namespace RestEaseClientGenerator.VSIX.Generators.RestEase
{
    public class RestEaseCSharpCodeGenerator : CodeGenerator
    {
        private readonly IRestEaseOptions options;

        public RestEaseCSharpCodeGenerator(
            string swaggerFile,
            string defaultNamespace,
            IRestEaseOptions options,
            IProcessLauncher processLauncher)
            : base(swaggerFile, defaultNamespace, processLauncher)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        protected override string GetArguments(string outputFile)
        {
            var args = "--csharp " +
                       $"--input-file=\"{SwaggerFile}\" " +
                       $"--output-file=\"{outputFile}\" " +
                       $"--namespace=\"{DefaultNamespace}\" ";

            if (options.AddCredentials)
                args += "--add-credentials ";

            args += $"--client-side-validation=\"{options.ClientSideValidation}\" ";
            args += $"--sync-methods=\"{options.SyncMethods}\" ";

            if (options.UseDateTimeOffset)
                args += "--use-datetimeoffset ";

            if (options.UseInternalConstructors)
                args += " --use-internal-constructors ";

            if (options.OverrideClientName)
            {
                var file = new FileInfo(SwaggerFile);
                var name = file.Name
                    .Replace(" ", string.Empty)
                    .Replace(file.Extension, string.Empty);

                args += $" --override-client-name=\"{name}\"";
            }

            return args;
        }

        protected override string GetCommand()
        {
            //var RestEaseCmd = PathProvider.GetRestEasePath();

            //if (!File.Exists(RestEaseCmd))
            //    DependencyDownloader.InstallRestEase();

            return ""; //RestEaseCmd;
        }
    }
}