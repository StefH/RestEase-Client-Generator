using System;
using System.Diagnostics;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.VSIX.Options.RestEase
{
    public class RestEaseOptions : OptionsBase<IRestEaseOptions, RestEaseOptionsPage>, IRestEaseOptions
    {
        public RestEaseOptions(IRestEaseOptions options)
        {
            try
            {
                if (options == null)
                {
                    options = GetFromDialogPage();
                }

                ArrayType = options.ArrayType;
                FailOnOpenApiErrors = options.FailOnOpenApiErrors;
                AddAuthorizationHeader = options.AddAuthorizationHeader;
                UseDateTimeOffset = options.UseDateTimeOffset;
                MethodReturnType = options.MethodReturnType;
                AppendAsync = options.AppendAsync;
                GenerateMultipartFormDataExtensionMethods = options.GenerateMultipartFormDataExtensionMethods;
                GenerateFormUrlEncodedExtensionMethods = options.GenerateFormUrlEncodedExtensionMethods;
                MultipartFormDataFileType = options.MultipartFormDataFileType;
                ApplicationOctetStreamType = options.ApplicationOctetStreamType;
                ApiNamespace = options.ApiNamespace;
                ModelsNamespace = options.ModelsNamespace;
                ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified = options.ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified;
            }
            catch (Exception e)
            {
                ArrayType = ArrayType.Array;
                FailOnOpenApiErrors = false;
                AddAuthorizationHeader = false;
                UseDateTimeOffset = false;
                MethodReturnType = MethodReturnType.Type;
                AppendAsync = true;
                GenerateMultipartFormDataExtensionMethods = true;
                GenerateFormUrlEncodedExtensionMethods = true;
                MultipartFormDataFileType = MultipartFormDataFileType.ByteArray;
                ApplicationOctetStreamType = ApplicationOctetStreamType.ByteArray;
                ApiNamespace = "Api";
                ModelsNamespace = "Models";
                ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified = false;

                Trace.WriteLine(e);
                Trace.WriteLine(Environment.NewLine);
                Trace.WriteLine("Error reading RestEase user options. Reverting to default values");
                Trace.WriteLine($"{nameof(ArrayType)} = {ArrayType}");
                Trace.WriteLine($"{nameof(FailOnOpenApiErrors)} = {FailOnOpenApiErrors}");
                Trace.WriteLine($"{nameof(AddAuthorizationHeader)} = {AddAuthorizationHeader}");
                Trace.WriteLine($"{nameof(UseDateTimeOffset)} = {UseDateTimeOffset}");
                Trace.WriteLine($"{nameof(MethodReturnType)} = {MethodReturnType}");
                Trace.WriteLine($"{nameof(AppendAsync)} = {AppendAsync}");
                Trace.WriteLine($"{nameof(GenerateMultipartFormDataExtensionMethods)} = {GenerateMultipartFormDataExtensionMethods}");
                Trace.WriteLine($"{nameof(GenerateFormUrlEncodedExtensionMethods)} = {GenerateFormUrlEncodedExtensionMethods}");
                Trace.WriteLine($"{nameof(MultipartFormDataFileType)} = {MultipartFormDataFileType}");
                Trace.WriteLine($"{nameof(ApplicationOctetStreamType)} = {ApplicationOctetStreamType}");
                Trace.WriteLine($"{nameof(ApiNamespace)} = {ApiNamespace}");
                Trace.WriteLine($"{nameof(ModelsNamespace)} = {ModelsNamespace}");
                Trace.WriteLine($"{nameof(ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified)} = {ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified}");
            }
        }

        public ArrayType ArrayType { get; set; }

        public MultipartFormDataFileType MultipartFormDataFileType { get; set; }

        public ApplicationOctetStreamType ApplicationOctetStreamType { get; set; }

        public bool FailOnOpenApiErrors { get; set; }

        public bool AddAuthorizationHeader { get; set; }

        public bool UseDateTimeOffset { get; set; }

        public MethodReturnType MethodReturnType { get; set; }

        public bool AppendAsync { get; set; }

        public bool GenerateMultipartFormDataExtensionMethods { get; set; }

        public bool GenerateFormUrlEncodedExtensionMethods { get; set; }

        public string ApiNamespace { get; set; }

        public string ModelsNamespace { get; set; }

        public bool ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified { get; set; }
    }
}