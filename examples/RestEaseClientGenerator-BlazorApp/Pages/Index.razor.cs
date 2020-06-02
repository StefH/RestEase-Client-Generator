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

        GeneratorSettings Settings = new GeneratorSettings
        {
            SingleFile = true,
            Namespace = "Examples.PetStoreOpenApi302"
        };
        bool _uploadComplete;

        string _fileName;
        Stream _inputStream;
        string _logMessages;

        async Task GenerateAndDownloadFile()
        {
            var bytes = CodeGenerator.GenerateZippedBytesFromInputStream(_inputStream, Settings, out OpenApiDiagnostic diagnostic);

            if (diagnostic.Errors.Any())
            {
                foreach (var error in diagnostic.Errors)
                {
                    _logMessages += $"Error: {error.Message}\r\n";
                }

                return;
            }

            string name = _fileName + ".zip";
            await BlazorDownloadFileService.DownloadFile(name, bytes);
        }

        async Task InputFileChanged(FileChangedEventArgs e)
        {
            _logMessages = string.Empty;
            _uploadComplete = false;
            _inputStream?.Dispose();

            try
            {
                var file = e.Files.First();

                _fileName = file.Name;

                _inputStream = new MemoryStream();

                await file.WriteToStreamAsync(_inputStream);
                _inputStream.Seek(0, SeekOrigin.Begin);

                _uploadComplete = true;

                Settings.Namespace = _fileName.ToPascalCase();
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