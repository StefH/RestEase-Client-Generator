using System.Collections.Generic;

namespace RestEaseClientGeneratorBlazorApp.Services
{
    public interface IFileZipper
    {
        byte[] Zip(ICollection<GeneratedFile> results);
    }
}
