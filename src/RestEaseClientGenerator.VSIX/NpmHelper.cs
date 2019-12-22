using System;
using System.Diagnostics;
using System.IO;
using RestEaseClientGenerator.VSIX.Generators;

namespace RestEaseClientGenerator.VSIX
{
    public static class NpmHelper
    {
        public static string GetNpmPath()
        {
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            var programFiles64 = programFiles.Replace(" (x86)", newValue: String.Empty);

            var npmCommand = Path.Combine(programFiles, "nodejs\\npm.cmd");
            if (File.Exists(npmCommand))
                return npmCommand;

            npmCommand = Path.Combine(programFiles64, "nodejs\\npm.cmd");
            if (!File.Exists(npmCommand))
                throw new InvalidOperationException("Unable to find NPM. Please install Node.js");

            return npmCommand;
        }

        public static string GetPrefixPath()
            => TryGetNpmPrefixPathFromNpmConfig() ??
               Path.Combine(
                   Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                   "npm");

        private static string TryGetNpmPrefixPathFromNpmConfig()
        {
            try
            {
                var npm = GetNpmPath();
                string prefix = null;
                new ProcessLauncher().Start(
                    npm,
                    "config get prefix",
                    o => prefix += o,
                    e => Trace.WriteLine(e));
                return prefix;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                return null;
            }
        }
    }
}