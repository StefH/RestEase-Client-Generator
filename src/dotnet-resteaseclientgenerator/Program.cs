using CommandLine;
using Microsoft.Extensions.Logging;

namespace DotNetRestEaseClientGenerator
{
    public class Program
    {
        public class Options
        {
            [Option('f', "CoverageFilesFolder", Required = true, HelpText = "The folder where the .coverage files are defined.")]
            public string CoverageFilesFolder { get; set; }

            [Option('d', "DotCoverageExtension", HelpText = "The extension from the coverage files.", Default = ".coverage")]
            public string DotCoverageExtension { get; set; }

            [Option('a', "AllDirectories", HelpText = "Includes also sub-folders in the search operation.", Default = true)]
            public bool AllDirectories { get; set; }

            [Option('p', "ProcessAllFiles", HelpText = "Process all .coverage files, if not set, then only folders which are a guid (that's the one VSTest creates) will be processed.", Default = false)]
            public bool ProcessAllFiles { get; set; }

            [Option('o', "Overwrite", HelpText = "Overwrite the existing .coveragexml files.", Default = true)]
            public bool Overwrite { get; set; }

            [Option('r', "RemoveOriginalCoverageFiles", HelpText = "Remove the original .coverage files.")]
            public bool RemoveOriginalCoverageFiles { get; set; }
        }

        /// <summary>
        /// The Logger.
        /// </summary>
        private static readonly ILogger<Program> Logger = LoggerFactory.Create(o =>
        {
            o.SetMinimumLevel(LogLevel.Information);
            o.AddConsole();
        }).CreateLogger<Program>();

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(Run);
        }

        private static void Run(Options options)
        {
            
        }
    }
}