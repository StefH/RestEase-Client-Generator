using System.Collections.Generic;
using RestEaseClientGenerator.Models.External;

namespace RestEaseClientGeneratorBlazorApp.Services
{
    public interface IFileZipper
    {
        byte[] Zip(ICollection<GeneratedFile> results);
    }
}
