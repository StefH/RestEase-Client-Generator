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

        public IRestEaseOptions Deserialize(string value)
        {
            throw new System.NotImplementedException();
        }

        public string Serialize(IRestEaseOptions options)
        {
            var stringBuilder = new StringBuilder();
            //stringBuilder.AppendLine("{");
            //stringBuilder.AppendLine("  /**/");

            using (var t = new JsonTextWriter(new StringWriter(stringBuilder)))
            {
                t.Formatting = Formatting.Indented;

                t.WriteStartObject();
                t.WriteComment("Use this file to overrule the RestEase Client Generator Options");

                t.WritePropertyName(nameof(options.AddAuthorizationHeader));
                t.WriteValue(options.AddAuthorizationHeader);

                t.WritePropertyName(nameof(options.ApiNamespace));
                t.WriteValue(options.ApiNamespace);

                t.WritePropertyName(nameof(options.AppendAsync));
                t.WriteValue(options.AppendAsync);

                t.WritePropertyName(nameof(options.ApplicationOctetStreamType));
                t.WriteValue(options.ApplicationOctetStreamType.GetDescription());
                WriteEnumComment<ApplicationOctetStreamType>(t);

                t.WritePropertyName(nameof(options.ArrayType));
                t.WriteValue(options.ArrayType.GetDescription());
                WriteEnumComment<ArrayType>(t);

                t.WritePropertyName(nameof(options.FailOnOpenApiErrors));
                t.WriteValue(options.FailOnOpenApiErrors);

                t.WritePropertyName(nameof(options.ForceContentTypeToApplicationJson));
                t.WriteValue(options.ForceContentTypeToApplicationJson);

                t.WritePropertyName(nameof(options.GenerateApplicationOctetStreamExtensionMethods));
                t.WriteValue(options.GenerateApplicationOctetStreamExtensionMethods);

                t.WritePropertyName(nameof(options.GenerateFormUrlEncodedExtensionMethods));
                t.WriteValue(options.GenerateFormUrlEncodedExtensionMethods);

                t.WritePropertyName(nameof(options.GenerateMultipartFormDataExtensionMethods));
                t.WriteValue(options.GenerateMultipartFormDataExtensionMethods);

                t.WritePropertyName(nameof(options.MethodReturnType));
                t.WriteValue(options.MethodReturnType.GetDescription());
                WriteEnumComment<MethodReturnType>(t);

                t.WritePropertyName(nameof(options.ModelsNamespace));
                t.WriteValue(options.ModelsNamespace);

                t.WritePropertyName(nameof(options.MultipartFormDataFileType));
                t.WriteValue(options.MultipartFormDataFileType.GetDescription());
                WriteEnumComment<MultipartFormDataFileType>(t);

                t.WritePropertyName(nameof(options.PreferredContentType));
                t.WriteValue(options.PreferredContentType.GetDescription());
                WriteEnumComment<ContentType>(t);

                t.WritePropertyName(nameof(options.ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified));
                t.WriteValue(options.ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified);

                t.WritePropertyName(nameof(options.UseDateTimeOffset));
                t.WriteValue(options.UseDateTimeOffset);

                t.WritePropertyName(nameof(options.UseOperationIdAsMethodName));
                t.WriteValue(options.UseOperationIdAsMethodName);

                t.WriteEndObject();
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