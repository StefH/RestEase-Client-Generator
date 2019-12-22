using System.Collections.Generic;

namespace RestEaseClientGenerator.VSIX.NuGet
{
    public class PackageDependencyListProvider
    {
        public IEnumerable<PackageDependency> GetDependencies(SupportedCodeGenerator generator)
        {
            switch (generator)
            {
                case SupportedCodeGenerator.AutoRest:
                    yield return PackageDependencies.RestEase;
                    break;
            }
        }
    }
}