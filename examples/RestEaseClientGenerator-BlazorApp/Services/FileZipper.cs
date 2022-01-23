using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using RestEaseClientGenerator.Models;

namespace RestEaseClientGeneratorBlazorApp.Services
{
    public class FileZipper : IFileZipper
    {
        public byte[] Zip(ICollection<GeneratedFile> results)
        {
            var memoryStream = new MemoryStream();
            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create))
            {
                foreach (var result in results)
                {
                    var readmeEntry = archive.CreateEntry(result.Name);
                    using var writer = new StreamWriter(readmeEntry.Open());
                    writer.Write(result.Content);
                }
            }

            return memoryStream.ToArray();
        }
    }
}