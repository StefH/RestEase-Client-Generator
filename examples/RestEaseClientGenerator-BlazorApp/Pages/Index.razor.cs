using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorDownloadFile;
using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Settings;
using RestEaseClientGeneratorBlazorApp.Models;
using RestEaseClientGeneratorBlazorApp.Services;

namespace RestEaseClientGeneratorBlazorApp.Pages
{
    public partial class Index
    {
        [Inject]
        IRestEaseCodeGenerator CodeGenerator { get; set; }

        [Inject]
        IBlazorDownloadFileService BlazorDownloadFileService { get; set; }

        GeneratorSettings settings = new GeneratorSettings
        {
            Namespace = "Example"
        };

        bool uploadButtonEnabled;
        FileModel fileModel = new FileModel();
        string logMessages = string.Empty;

        async Task GenerateAndDownloadFile()
        {
            if (fileModel.Content is null)
            {
                return;
            }

            uploadButtonEnabled = false;

            var bytes = CodeGenerator.GenerateZippedBytesFromString(fileModel.Content, settings, out OpenApiDiagnostic diagnostic);

            if (diagnostic.Errors.Any())
            {
                logMessages += "OpenApiWarnings:\r\n";
                foreach (var error in diagnostic.Errors)
                {
                    logMessages += $"- {error.Message}\r\n";
                }
            }

            string name = $"{Path.GetFileNameWithoutExtension(fileModel.Name)}.zip";
            await BlazorDownloadFileService.DownloadFile(name, bytes);

            uploadButtonEnabled = true;
        }

        async Task InputFileChanged(FileChangedEventArgs e)
        {
            logMessages = string.Empty;
            uploadButtonEnabled = false;

            try
            {
                var file = e.Files.First();

                // A stream is going to be the destination stream we're writing to.                
                using (var stream = new MemoryStream())
                {
                    // Here we're telling the FileEdit where to write the upload result
                    await file.WriteToStreamAsync(stream);

                    // Once we reach this line it means the file is fully uploaded.
                    // In this case we're going to offset to the beginning of file
                    // so we can read it.
                    stream.Seek(0, SeekOrigin.Begin);

                    // Use the stream reader to read the content of uploaded file,
                    // in this case we can assume it is a text file.
                    using (var reader = new StreamReader(stream))
                    {
                        fileModel.Content = await reader.ReadToEndAsync();
                    }
                }

                uploadButtonEnabled = true;

                logMessages = $"File '{file.Name}' ({file.Size} bytes) uploaded successfully.\r\n";

                fileModel.Name = file.Name;
                settings.ApiName = fileModel.Name.ToPascalCase();
            }
            catch (Exception ex)
            {
                logMessages += ex.Message;
            }
            finally
            {
                StateHasChanged();
            }
        }
    }
}