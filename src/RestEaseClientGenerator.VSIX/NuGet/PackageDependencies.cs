using System;

namespace RestEaseClientGenerator.VSIX.NuGet
{
    public static class PackageDependencies
    {
        public static readonly PackageDependency RestEase =
            new PackageDependency(
                "RestEase",
                new Version(1, 4, 10, 0));
    }
}