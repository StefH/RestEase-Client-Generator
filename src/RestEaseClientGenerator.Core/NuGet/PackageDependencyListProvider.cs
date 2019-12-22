﻿using System.Collections.Generic;

namespace ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.NuGet
{
    public class PackageDependencyListProvider
    {
        public IEnumerable<PackageDependency> GetDependencies(
            SupportedCodeGenerator generator)
        {
            switch (generator)
            {
                case SupportedCodeGenerator.RestEase:
                    yield return PackageDependencies.RestEase;
                    break;
            }
        }
    }
}