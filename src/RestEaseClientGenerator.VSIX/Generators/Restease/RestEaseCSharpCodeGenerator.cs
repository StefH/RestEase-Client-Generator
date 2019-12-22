using RestEaseClientCodeGeneratorVSIX.Options.AutoRest;
using System;
using System.IO;

namespace RestEaseClientCodeGeneratorVSIX.Generators.Restease
{
    public class RestEaseCSharpCodeGenerator : CodeGenerator
    {
        private readonly IRestEaseOptions _options;

        public RestEaseCSharpCodeGenerator(
            string swaggerFile,
            string defaultNamespace,
            IRestEaseOptions options,
            IProcessLauncher processLauncher)
            : base(swaggerFile, defaultNamespace, processLauncher)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        protected override string GetArguments(string outputFile)
        {
            var args = "--csharp " +
                       $"--input-file=\"{SwaggerFile}\" " +
                       $"--output-file=\"{outputFile}\" " +
                       $"--namespace=\"{DefaultNamespace}\" ";

            if (_options.AddCredentials)
                args += "--add-credentials ";

            args += $"--client-side-validation=\"{_options.ClientSideValidation}\" ";
            args += $"--sync-methods=\"{_options.SyncMethods}\" ";

            if (_options.UseDateTimeOffset)
                args += "--use-datetimeoffset ";

            if (_options.UseInternalConstructors)
                args += " --use-internal-constructors ";

            if (_options.OverrideClientName)
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
            //var autorestCmd = PathProvider.GetAutoRestPath();

            //if (!File.Exists(autorestCmd))
            //    DependencyDownloader.InstallAutoRest();

            return "";
        }
    }
}