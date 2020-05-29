﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.Services;
using BlazorDownloadFile;
using Blazored.TextEditor;
using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace BlazorApp.Pages
{
    public partial class Index
    {
        [Inject]
        IRestEaseCodeGenerator CodeGenerator { get; set; }

        [Inject]
        IBlazorDownloadFileService BlazorDownloadFileService { get; set; }

        private GeneratorSettings Settings = new GeneratorSettings
        {
            SingleFile = true,
            Namespace = "Examples.PetStoreOpenApi302"
        };
        private bool _uploadComplete;

        private string _fileName;
        private Stream _inputStream;

        BlazoredTextEditor QuillHtml { get; set; }

        async Task GenerateAndDownloadFile()
        {
            Settings.ApiName = Path.GetFileNameWithoutExtension(_fileName);
            Settings.GenerateFormUrlEncodedExtensionMethods = true;
            Settings.GenerateMultipartFormDataExtensionMethods = true;
            Settings.GenerateApplicationOctetStreamExtensionMethods = true;
            Settings.ApplicationOctetStreamType = ApplicationOctetStreamType.ByteArray;
            Settings.PreferredContentType = ContentType.ApplicationJson;
            Settings.DefineAllMethodHeadersOnInterface = true;
            Settings.MethodReturnType = MethodReturnType.Type;
            Settings.PreferredEnumType = EnumType.Enum;
            
            var result = CodeGenerator.GenerateFromStream(_inputStream, Settings, out OpenApiDiagnostic diagnostic);

            var first = result.First();
            string name = first.Name + ".zip";
            await BlazorDownloadFileService.DownloadFile(name, Encoding.UTF8.GetBytes(first.Content));
        }

        async Task InputFileChanged(FileChangedEventArgs e)
        {
            _uploadComplete = false;
            //Result = null;
            _inputStream?.Dispose();

            try
            {
                var file = e.Files.First();

                _fileName = file.Name;

                _inputStream = new MemoryStream();

                await file.WriteToStreamAsync(_inputStream);
                _inputStream.Seek(0, SeekOrigin.Begin);


                //await QuillHtml.LoadHTMLContent(Contents);
                //StateHasChanged();

                _uploadComplete = true;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                this.StateHasChanged();
            }
        }
    }
}