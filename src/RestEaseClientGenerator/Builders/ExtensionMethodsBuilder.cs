using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestEaseClientGenerator.Constants;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Builders
{
    internal class ExtensionMethodsBuilder : BaseBuilder
    {
        public ExtensionMethodsBuilder(GeneratorSettings settings) : base(settings)
        {
        }

        public string Build(RestEaseInterface @interface, string apiName)
        {
            var methods = @interface.Methods
                .Where(m => m.ExtensionMethodDetails != null)
                .ToList();

            if (!methods.Any())
            {
                return null;
            }

            var builder = new StringBuilder();
            if (!Settings.SingleFile)
            {
                builder.AppendLine("using System;");
                builder.AppendLine("using System.Collections.Generic;");
                builder.AppendLine("using System.Net.Http;");
                builder.AppendLine("using System.Threading.Tasks;");
                builder.AppendLine("using RestEase;");
                builder.AppendLine($"using {AppendModelsNamespace(@interface.Namespace)};");
            }

            builder.AppendLine();
            builder.AppendLine($"namespace {AppendApiNamespace(@interface.Namespace)}");
            builder.AppendLine("{");
            builder.AppendLine($"    public static class {new string(apiName.Skip(1).ToArray())}Extensions");
            builder.AppendLine("    {");

            foreach (var method in methods)
            {
                string asyncPostfix = Settings.AppendAsync ? "Async" : string.Empty;

                builder.AppendLine("        /// <summary>");
                builder.AppendLine($"        /// {method.ExtensionMethodDetails.Summary.StripHtml()}");
                builder.AppendLine("        /// </summary>");
                foreach (var p in method.ExtensionMethodDetails.SummaryParameters)
                {
                    builder.AppendLine($"        /// {p}");
                }
                builder.AppendLine($"        public static {method.ExtensionMethodDetails.RestEaseMethod.ReturnType} {method.ExtensionMethodDetails.RestEaseMethod.Name}{asyncPostfix}({method.ExtensionMethodDetails.RestEaseMethod.ParametersAsString})");
                builder.AppendLine("        {");

                switch (method.ExtensionMethodContentType)
                {
                    case SupportedContentTypes.MultipartFormData:
                        BuildMultipartFormDataExtensionMethodBody(Settings, builder, method);
                        break;

                    case SupportedContentTypes.ApplicationOctetStream:
                        BuildApplicationOctetStreamExtensionMethodBody(Settings, builder, method);
                        break;

                    case SupportedContentTypes.ApplicationFormUrlEncoded:
                        BuildApplicationFormUrlEncodedExtensionMethodBody(Settings, builder, method);
                        break;
                }

                builder.AppendLine($"            return api.{method.ExtensionMethodDetails.RestEaseMethod.Name}{asyncPostfix}({string.Join(", ", method.RestEaseMethod.Parameters.Select(p => p.Identifier))});");
                builder.AppendLine("        }");

                if (method != methods.Last())
                {
                    builder.AppendLine();
                }
            }
            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }

        private static void BuildApplicationFormUrlEncodedExtensionMethodBody(GeneratorSettings settings, StringBuilder builder, RestEaseInterfaceMethodDetails method)
        {
            builder.AppendLine("            var form = new Dictionary<string, object>");
            builder.AppendLine("            {");
            foreach (var parameter in method.ExtensionMethodParameters)
            {
                string comma = parameter != method.ExtensionMethodParameters.Last() ? "," : string.Empty;
                builder.AppendLine($"                {{ \"{parameter.Identifier}\", {parameter.Identifier} }}{comma}");
            }
            builder.AppendLine("            };");
            builder.AppendLine();
        }

        private static void BuildMultipartFormDataExtensionMethodBody(GeneratorSettings settings, StringBuilder builder, RestEaseInterfaceMethodDetails method)
        {
            builder.AppendLine("            var content = new MultipartFormDataContent();");
            builder.AppendLine();

            var formUrlEncodedContentList = new List<string>();
            foreach (var parameter in method.ExtensionMethodParameters)
            {
                switch (parameter.SchemaType)
                {
                    case SchemaType.File:
                        string identifierName = $"{parameter.Identifier}Content";
                        switch (settings.MultipartFormDataFileType)
                        {
                            case MultipartFormDataFileType.Stream:
                                builder.AppendLine($"            var {identifierName} = new StreamContent({parameter.Identifier});");
                                break;

                            default:
                                builder.AppendLine($"            var {identifierName} = new ByteArrayContent({parameter.Identifier});");
                                break;
                        }

                        builder.AppendLine($"            content.Add({identifierName});");
                        builder.AppendLine();
                        break;

                    default:
                        formUrlEncodedContentList.Add(parameter.Identifier);
                        break;
                }
            }

            if (formUrlEncodedContentList.Any())
            {
                builder.AppendLine("            var formUrlEncodedContent = new FormUrlEncodedContent(new[] {");
                foreach (var formUrlEncodedContent in formUrlEncodedContentList)
                {
                    string comma = formUrlEncodedContent != formUrlEncodedContentList.Last() ? "," : string.Empty;
                    builder.AppendLine(
                        $"                new KeyValuePair<string, string>(\"{formUrlEncodedContent}\", {formUrlEncodedContent}.ToString()){comma}");
                }

                builder.AppendLine("            });");
                builder.AppendLine();
                builder.AppendLine("            content.Add(formUrlEncodedContent);");
            }
        }

        private static void BuildApplicationOctetStreamExtensionMethodBody(GeneratorSettings settings, StringBuilder builder, RestEaseInterfaceMethodDetails method)
        {
            builder.AppendLine("            var content = new MultipartFormDataContent();");
            builder.AppendLine();

            var formUrlEncodedContentList = new List<string>();
            foreach (var parameter in method.ExtensionMethodParameters)
            {
                switch (parameter.SchemaType)
                {
                    case SchemaType.String:
                        switch (parameter.SchemaFormat)
                        {
                            case SchemaFormat.Binary:
                            case SchemaFormat.Byte:
                                string identifierName = $"{parameter.Identifier}Content";
                                switch (settings.ApplicationOctetStreamType)
                                {
                                    case ApplicationOctetStreamType.Stream:
                                        builder.AppendLine($"            var {identifierName} = new StreamContent({parameter.Identifier});");
                                        break;

                                    default:
                                        builder.AppendLine($"            var {identifierName} = new ByteArrayContent({parameter.Identifier});");
                                        break;
                                }

                                builder.AppendLine($"            content.Add({identifierName});");
                                builder.AppendLine();

                                break;

                            default:
                                formUrlEncodedContentList.Add(parameter.Identifier);
                                break;
                        }
                        break;

                    default:
                        formUrlEncodedContentList.Add(parameter.Identifier);
                        break;
                }
            }

            if (formUrlEncodedContentList.Any())
            {
                builder.AppendLine("            var formUrlEncodedContent = new FormUrlEncodedContent(new[] {");
                foreach (var formUrlEncodedContent in formUrlEncodedContentList)
                {
                    string comma = formUrlEncodedContent != formUrlEncodedContentList.Last() ? "," : string.Empty;
                    builder.AppendLine(
                        $"                new KeyValuePair<string, string>(\"{formUrlEncodedContent}\", {formUrlEncodedContent}.ToString()){comma}");
                }

                builder.AppendLine("            });");
                builder.AppendLine();
                builder.AppendLine("            content.Add(formUrlEncodedContent);");
            }
        }
    }
}