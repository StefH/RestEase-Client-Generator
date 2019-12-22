using System.Collections.Generic;

namespace RestEaseClientCodeGeneratorVSIX.NuGet
{
    public class PackageDependencyListProvider
    {
        public IEnumerable<PackageDependency> GetDependencies(SupportedCodeGenerator generator)
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