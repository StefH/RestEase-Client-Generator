using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.VSIX.Options.RestEase;

namespace RestEaseClientGenerator.VSIX.Options
{
    public class OptionsFactory : IOptionsFactory
    {
        public IRestEaseOptions Create<TDialogPage>() => VsPackage.Instance.GetDialogPage(typeof(TDialogPage)) as IRestEaseOptions;

        public RestEaseUserOptions Deserialize(string value)
        {
            return JsonConvert.DeserializeObject<RestEaseUserOptions>(value);
        }

        public string Serialize(IRestEaseOptions options)
        {
            var stringBuilder = new StringBuilder();

            using (var textWriter = new JsonTextWriter(new StringWriter(stringBuilder)))
            {
                textWriter.Formatting = Formatting.Indented;

                textWriter.WriteStartObject();
                textWriter.WriteComment("Use this file to overrule the RestEase Client Generator Options");

                textWriter.WritePropertyName(nameof(options.ApiNamespace));
                textWriter.WriteValue(options.ApiNamespace);

                textWriter.WritePropertyName(nameof(options.AppendAsync));
                textWriter.WriteValue(options.AppendAsync);

                textWriter.WritePropertyName(nameof(options.ApplicationOctetStreamType));
                textWriter.WriteValue(options.ApplicationOctetStreamType.GetDescription());
                WriteEnumComment<ApplicationOctetStreamType>(textWriter);

                textWriter.WritePropertyName(nameof(options.ArrayType));
                textWriter.WriteValue(options.ArrayType.GetDescription());
                WriteEnumComment<ArrayType>(textWriter);

                textWriter.WritePropertyName(nameof(options.FailOnOpenApiErrors));
                textWriter.WriteValue(options.FailOnOpenApiErrors);

                textWriter.WritePropertyName(nameof(options.ForceContentTypeToApplicationJson));
                textWriter.WriteValue(options.ForceContentTypeToApplicationJson);

                textWriter.WritePropertyName(nameof(options.GenerateApplicationOctetStreamExtensionMethods));
                textWriter.WriteValue(options.GenerateApplicationOctetStreamExtensionMethods);

                textWriter.WritePropertyName(nameof(options.GenerateMultipartFormDataExtensionMethods));
                textWriter.WriteValue(options.GenerateMultipartFormDataExtensionMethods);

                textWriter.WritePropertyName(nameof(options.GenerateFormUrlEncodedExtensionMethods));
                textWriter.WriteValue(options.GenerateFormUrlEncodedExtensionMethods);

                textWriter.WritePropertyName(nameof(options.GeneratePrimitivePropertiesAsNullableForOpenApi20));
                textWriter.WriteValue(options.GeneratePrimitivePropertiesAsNullableForOpenApi20);

                textWriter.WritePropertyName(nameof(options.MakeNonRequiredParametersOptional));
                textWriter.WriteValue(options.MakeNonRequiredParametersOptional);

                textWriter.WritePropertyName(nameof(options.MethodReturnType));
                textWriter.WriteValue(options.MethodReturnType.GetDescription());
                WriteEnumComment<MethodReturnType>(textWriter);

                textWriter.WritePropertyName(nameof(options.ModelsNamespace));
                textWriter.WriteValue(options.ModelsNamespace);

                textWriter.WritePropertyName(nameof(options.MultipartFormDataFileType));
                textWriter.WriteValue(options.MultipartFormDataFileType.GetDescription());
                WriteEnumComment<MultipartFormDataFileType>(textWriter);

                textWriter.WritePropertyName(nameof(options.PreferredContentType));
                textWriter.WriteValue(options.PreferredContentType.GetDescription());
                WriteEnumComment<ContentType>(textWriter);

                textWriter.WritePropertyName(nameof(options.PreferredSecurityDefinitionType));
                textWriter.WriteValue(options.PreferredSecurityDefinitionType.GetDescription());
                WriteEnumComment<SecurityDefinitionType>(textWriter);

                textWriter.WritePropertyName(nameof(options.ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified));
                textWriter.WriteValue(options.ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified);

                textWriter.WritePropertyName(nameof(options.UseDateTimeOffset));
                textWriter.WriteValue(options.UseDateTimeOffset);

                textWriter.WritePropertyName(nameof(options.UseOperationIdAsMethodName));
                textWriter.WriteValue(options.UseOperationIdAsMethodName);

                textWriter.WriteEndObject();
            }

            return stringBuilder.ToString();
        }

        private void WriteEnumComment<T>(JsonTextWriter writer)
        {
            var descriptions = new List<string>();
            foreach (Enum value in Enum.GetValues(typeof(T)))
            {
                descriptions.Add($"'{value.GetDescription()}'");
            }

            writer.WriteComment($"Possible values are: {string.Join(", ", descriptions)}");
        }
    }
}