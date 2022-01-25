using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.DownloadFileFast.Interfaces;
using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGeneratorBlazorApp.Extensions;
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

        [Inject]
        HttpClient HttpClient { get; set; }

        SettingsModel settings = new SettingsModel
        {
            Namespace = "Example"
        };

        private bool downloadFromUrlButtonEnabled = true;
        bool uploadButtonEnabled;
        string logMessages = string.Empty;

        async Task DownloadFromUrl()
        {
            uploadButtonEnabled = false;
            downloadFromUrlButtonEnabled = false;

            try
            {
                settings.Content = await HttpClient.GetStringAsync(settings.SourceUrl);

                settings.FileName = Path.GetFileName(settings.SourceUrl);
                settings.ApiName = Path.GetFileNameWithoutExtension(settings.SourceUrl).ToPascalCase();

                logMessages = $"File '{settings.FileName}' ({settings.Content.Length} bytes) downloaded successfully.\r\n";
            }
            catch (Exception ex)
            {
                logMessages += ex.Message;
            }
            finally
            {
                uploadButtonEnabled = true;
                downloadFromUrlButtonEnabled = true;
            }
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
                        settings.Content = await reader.ReadToEndAsync();
                    }
                }

                uploadButtonEnabled = true;

                logMessages = $"File '{file.Name}' ({file.Size} bytes) uploaded successfully.\r\n";

                settings.FileName = file.Name;
                settings.ApiName = Path.GetFileNameWithoutExtension(file.Name).ToPascalCase();
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

        async Task GenerateAndDownloadFile()
        {
            if (settings.Content is null)
            {
                return;
            }

            uploadButtonEnabled = false;

            var bytes = CodeGenerator.GenerateZippedBytesFromString(settings.Content, settings, out OpenApiDiagnostic diagnostic);

            if (diagnostic.Errors.Any())
            {
                logMessages += "OpenApiWarnings:\r\n";
                foreach (var error in diagnostic.Errors)
                {
                    logMessages += $"- {error.Message}\r\n";
                }
            }

            string name = $"{Path.GetFileNameWithoutExtension(settings.FileName)}.zip";
            await BlazorDownloadFileService.DownloadFileAsync(name, bytes);

            uploadButtonEnabled = true;
        }
    }
}