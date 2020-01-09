using System;
using System.Diagnostics;
using Newtonsoft.Json;
using RestEaseClientGenerator.Json;
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
                UseDateTimeOffset = options.UseDateTimeOffset;
                MethodReturnType = options.MethodReturnType;
                AppendAsync = options.AppendAsync;
                GenerateMultipartFormDataExtensionMethods = options.GenerateMultipartFormDataExtensionMethods;
                GenerateFormUrlEncodedExtensionMethods = options.GenerateFormUrlEncodedExtensionMethods;
                GenerateApplicationOctetStreamExtensionMethods = options.GenerateApplicationOctetStreamExtensionMethods;
                MultipartFormDataFileType = options.MultipartFormDataFileType;
                ApplicationOctetStreamType = options.ApplicationOctetStreamType;
                ApiNamespace = options.ApiNamespace;
                ModelsNamespace = options.ModelsNamespace;
                ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified = options.ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified;
                PreferredContentType = options.PreferredContentType;
                ForceContentTypeToApplicationJson = options.ForceContentTypeToApplicationJson;
                UseOperationIdAsMethodName = options.UseOperationIdAsMethodName;
                PreferredSecurityDefinitionType = options.PreferredSecurityDefinitionType;
                UseUserOptions = options.UseUserOptions;
                MakeNonRequiredParametersOptional = options.MakeNonRequiredParametersOptional;
            }
            catch (Exception e)
            {
                ArrayType = ArrayType.Array;
                FailOnOpenApiErrors = false;
                UseDateTimeOffset = false;
                MethodReturnType = MethodReturnType.Type;
                AppendAsync = true;
                GenerateMultipartFormDataExtensionMethods = true;
                GenerateFormUrlEncodedExtensionMethods = true;
                GenerateApplicationOctetStreamExtensionMethods = true;
                MultipartFormDataFileType = MultipartFormDataFileType.ByteArray;
                ApplicationOctetStreamType = ApplicationOctetStreamType.ByteArray;
                ApiNamespace = "Api";
                ModelsNamespace = "Models";
                ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified = false;
                PreferredContentType = ContentType.ApplicationJson;
                ForceContentTypeToApplicationJson = false;
                UseOperationIdAsMethodName = true;
                UseUserOptions = true;
                PreferredSecurityDefinitionType = SecurityDefinitionType.Automatic;
                MakeNonRequiredParametersOptional = true;

                Trace.WriteLine(e);
                Trace.WriteLine(Environment.NewLine);
                Trace.WriteLine("Error reading RestEase user options. Reverting to default values");
                Trace.WriteLine($"{nameof(ArrayType)} = {ArrayType}");
                Trace.WriteLine($"{nameof(FailOnOpenApiErrors)} = {FailOnOpenApiErrors}");
                Trace.WriteLine($"{nameof(UseDateTimeOffset)} = {UseDateTimeOffset}");
                Trace.WriteLine($"{nameof(MethodReturnType)} = {MethodReturnType}");
                Trace.WriteLine($"{nameof(AppendAsync)} = {AppendAsync}");
                Trace.WriteLine($"{nameof(GenerateMultipartFormDataExtensionMethods)} = {GenerateMultipartFormDataExtensionMethods}");
                Trace.WriteLine($"{nameof(GenerateFormUrlEncodedExtensionMethods)} = {GenerateFormUrlEncodedExtensionMethods}");
                Trace.WriteLine($"{nameof(GenerateApplicationOctetStreamExtensionMethods)} = {GenerateApplicationOctetStreamExtensionMethods}");
                Trace.WriteLine($"{nameof(MultipartFormDataFileType)} = {MultipartFormDataFileType}");
                Trace.WriteLine($"{nameof(ApplicationOctetStreamType)} = {ApplicationOctetStreamType}");
                Trace.WriteLine($"{nameof(ApiNamespace)} = {ApiNamespace}");
                Trace.WriteLine($"{nameof(ModelsNamespace)} = {ModelsNamespace}");
                Trace.WriteLine($"{nameof(ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified)} = {ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified}");
                Trace.WriteLine($"{nameof(PreferredContentType)} = {PreferredContentType}");
                Trace.WriteLine($"{nameof(ForceContentTypeToApplicationJson)} = {ForceContentTypeToApplicationJson}");
                Trace.WriteLine($"{nameof(UseOperationIdAsMethodName)} = {UseOperationIdAsMethodName}");
                Trace.WriteLine($"{nameof(UseUserOptions)} = {UseUserOptions}");
                Trace.WriteLine($"{nameof(PreferredSecurityDefinitionType)} = {PreferredSecurityDefinitionType}");
                Trace.WriteLine($"{nameof(MakeNonRequiredParametersOptional)} = {MakeNonRequiredParametersOptional}");
            }
        }

        [JsonConverter(typeof(DescriptionEnumConverter))]
        public ArrayType ArrayType { get; set; }

        [JsonConverter(typeof(DescriptionEnumConverter))]
        public MultipartFormDataFileType MultipartFormDataFileType { get; set; }

        [JsonConverter(typeof(DescriptionEnumConverter))]
        public ApplicationOctetStreamType ApplicationOctetStreamType { get; set; }

        public bool FailOnOpenApiErrors { get; set; }

        public bool UseDateTimeOffset { get; set; }

        [JsonConverter(typeof(DescriptionEnumConverter))]
        public MethodReturnType MethodReturnType { get; set; }

        public bool AppendAsync { get; set; }

        public bool GenerateMultipartFormDataExtensionMethods { get; set; }

        public bool GenerateFormUrlEncodedExtensionMethods { get; set; }

        public bool GenerateApplicationOctetStreamExtensionMethods { get; set; }

        public string ApiNamespace { get; set; }

        public string ModelsNamespace { get; set; }

        public bool ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified { get; set; }

        [JsonConverter(typeof(DescriptionEnumConverter))]
        public ContentType PreferredContentType { get; set; }

        public bool ForceContentTypeToApplicationJson { get; set; }

        public bool UseOperationIdAsMethodName { get; set; }

        [JsonConverter(typeof(DescriptionEnumConverter))]
        public SecurityDefinitionType PreferredSecurityDefinitionType { get; set; }

        public bool UseUserOptions { get; set; }

        public bool MakeNonRequiredParametersOptional { get; set; }
    }
}