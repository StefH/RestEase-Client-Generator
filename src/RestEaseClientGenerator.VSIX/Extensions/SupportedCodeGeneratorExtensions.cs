using System;
using System.Collections.Generic;
using RestEaseClientGenerator.VSIX.CustomTool;
using RestEaseClientGenerator.VSIX.NuGet;

namespace RestEaseClientGenerator.VSIX.Extensions
{
    public static class SupportedCodeGeneratorExtensions
    {
        private static readonly PackageDependencyListProvider DependencyListProvider
            = new PackageDependencyListProvider();

        public static string GetCustomToolName(this SupportedCodeGenerator generator)
        {
            string customTool = null;
            switch (generator)
            {
                case SupportedCodeGenerator.RestEase:
                    customTool = nameof(RestEaseCodeGenerator);
                    break;
            }

            return customTool;
        }

        public static SupportedCodeGenerator GetSupportedCodeGenerator(this Type type)
        {
            if (type.IsAssignableFrom(typeof(RestEaseCodeGenerator)))
            {
                return SupportedCodeGenerator.RestEase;
            }

            throw new NotSupportedException();
        }

        public static IEnumerable<PackageDependency> GetDependencies(this SupportedCodeGenerator generator) => DependencyListProvider.GetDependencies(generator);
    }
}