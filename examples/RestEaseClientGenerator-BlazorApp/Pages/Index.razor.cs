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
            Namespace = "Examples"
        };
        bool uploadComplete;

        string fileName = string.Empty;
        Stream inputStream;
        private string _logMessages = string.Empty;

        async Task GenerateAndDownloadFile()
        {
            inputStream.Seek(0, SeekOrigin.Begin);

            var bytes = CodeGenerator.GenerateZippedBytesFromInputStream(inputStream, settings, out OpenApiDiagnostic diagnostic);

            if (diagnostic.Errors.Any())
            {
                _logMessages = "OpenApiWarnings:\r\n";
                foreach (var error in diagnostic.Errors)
                {
                    _logMessages += $"- {error.Message}\r\n";
                }
            }

            string name = fileName + ".zip";
            await BlazorDownloadFileService.DownloadFile(name, bytes);
        }

        async Task InputFileChanged(FileChangedEventArgs e)
        {
            _logMessages = string.Empty;
            uploadComplete = false;
            inputStream?.Dispose();

            try
            {
                var file = e.Files.First();

                fileName = file.Name;

                inputStream = new MemoryStream();

                await file.WriteToStreamAsync(inputStream);

                uploadComplete = true;

                settings.ApiName = fileName.ToPascalCase();

                _logMessages = $"File '{fileName}' uploaded successfully.";
            }
            catch (Exception ex)
            {
                _logMessages += ex.Message;
            }
            finally
            {
                StateHasChanged();
            }
        }
    }
}