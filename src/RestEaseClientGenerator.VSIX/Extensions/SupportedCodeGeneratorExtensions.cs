using System;
using System.Collections.Generic;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.NuGet;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.CustomTool.AutoRest;

namespace ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Extensions
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
                case SupportedCodeGenerator.AutoRest:
                    customTool = nameof(AutoRestCodeGenerator);
                    break;
            }

            return customTool;
        }

        public static SupportedCodeGenerator GetSupportedCodeGenerator(this Type type)
        {

            if (type.IsAssignableFrom(typeof(AutoRestCodeGenerator)))
                return SupportedCodeGenerator.AutoRest;

            throw new NotSupportedException();
        }

        public static IEnumerable<PackageDependency> GetDependencies(this SupportedCodeGenerator generator) => DependencyListProvider.GetDependencies(generator);
    }
}