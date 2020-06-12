using System.Collections.Generic;
using RestEaseClientGenerator.Models;

namespace RestEaseClientGeneratorBlazorApp.Services
{
    public interface IFileZipper
    {
        byte[] Zip(ICollection<GeneratedFile> results);
    }
}
