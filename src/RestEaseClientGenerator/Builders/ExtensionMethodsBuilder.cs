using System.Text;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Builders;

internal class ExtensionMethodsBuilder : BaseBuilder
{
    public ExtensionMethodsBuilder(GeneratorSettings settings) : base(settings)
    {
    }

    public string? Build(RestEaseInterface @interface, string apiName)
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
            builder.AppendLine("using AnyOfTypes;");
            builder.AppendLine("using RestEase;");
            builder.AppendLine($"using {AppendModelsNamespace(@interface.Namespace)};");
        }

        builder.AppendLine();
        builder.AppendLine($"namespace {AppendApiNamespace(@interface.Namespace)}");
        builder.AppendLine("{");
        builder.AppendLine($"    public static class {apiName.Substring(1)}Extensions");
        builder.AppendLine("    {");

        foreach (var method in methods)
        {
            string asyncPostfix = Settings.AppendAsync ? "Async" : string.Empty;

            builder.AppendLine("        /// <summary>");
            builder.AppendLine($"        /// {method.ExtensionMethodDetails.Summary.StripHtml()}");
            builder.AppendLine("        /// </summary>");
            foreach (var sp in method.ExtensionMethodDetails.SummaryParameters)
            {
                builder.AppendLine($"        /// <param name=\"{sp.ValidIdentifier}\">{sp.Summary.StripHtml()}</param>");
            }

            string paramsAsString = string.Join(", ", method.ExtensionMethodDetails.RestEaseMethod.Parameters.Select(mp => mp.IdentifierWithType));
            builder.AppendLine($"        public static {method.ExtensionMethodDetails.RestEaseMethod.ReturnType} {method.ExtensionMethodDetails.RestEaseMethod.Name}{asyncPostfix}({paramsAsString})");
            builder.AppendLine("        {");

            switch (method.ExtensionMethodContentType)
            {
                case SupportedContentType.MultipartFormData:
                    BuildMultipartFormDataExtensionMethodBody(builder, method);
                    break;

                case SupportedContentType.ApplicationOctetStream:
                    BuildApplicationOctetStreamExtensionMethodBody(builder, method);
                    break;

                case SupportedContentType.ApplicationFormUrlEncoded:
                    BuildApplicationFormUrlEncodedExtensionMethodBody(builder, method);
                    break;
            }

            builder.AppendLine($"            return api.{method.ExtensionMethodDetails.RestEaseMethod.Name}{asyncPostfix}({string.Join(", ", method.RestEaseMethod.Parameters.Select(p => p.ValidIdentifier))});");
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

    private void BuildApplicationFormUrlEncodedExtensionMethodBody(StringBuilder builder, RestEaseInterfaceMethodDetails method)
    {
        builder.AppendLine("            var form = new Dictionary<string, object>");
        builder.AppendLine("            {");
        foreach (var parameter in method.ExtensionMethodParameters)
        {
            string comma = parameter != method.ExtensionMethodParameters.Last() ? "," : string.Empty;
            builder.AppendLine($"                {{ \"{parameter.ValidIdentifier}\", {parameter.ValidIdentifier} }}{comma}");
        }
        builder.AppendLine("            };");
        builder.AppendLine();
    }

    private void BuildMultipartFormDataExtensionMethodBody(StringBuilder builder, RestEaseInterfaceMethodDetails method)
    {
        builder.AppendLine("            var content = new MultipartFormDataContent();");
        builder.AppendLine();

        var formUrlEncodedContentList = new List<string>();
        foreach (var parameter in method.ExtensionMethodParameters)
        {
            switch (parameter.SchemaType)
            {
                case SchemaType.File:
                    string identifierName = $"{parameter.ValidIdentifier}Content";
                    switch (Settings.MultipartFormDataFileType)
                    {
                        case MultipartFormDataFileType.Stream:
                            builder.AppendLine($"            var {identifierName} = new StreamContent({parameter.ValidIdentifier});");
                            break;

                        default:
                            builder.AppendLine($"            var {identifierName} = new ByteArrayContent({parameter.ValidIdentifier});");
                            break;
                    }

                    builder.AppendLine($"            content.Add({identifierName});");
                    builder.AppendLine();
                    break;

                default:
                    formUrlEncodedContentList.Add(parameter.ValidIdentifier);
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

    private void BuildApplicationOctetStreamExtensionMethodBody(StringBuilder builder, RestEaseInterfaceMethodDetails method)
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
                            string identifierName = $"{parameter.ValidIdentifier}Content";
                            switch (Settings.ApplicationOctetStreamType)
                            {
                                case ApplicationOctetStreamType.Stream:
                                    builder.AppendLine($"            var {identifierName} = new StreamContent({parameter.ValidIdentifier});");
                                    break;

                                default:
                                    builder.AppendLine($"            var {identifierName} = new ByteArrayContent({parameter.ValidIdentifier});");
                                    break;
                            }

                            builder.AppendLine($"            content.Add({identifierName});");
                            builder.AppendLine();

                            break;

                        default:
                            formUrlEncodedContentList.Add(parameter.ValidIdentifier);
                            break;
                    }
                    break;

                default:
                    formUrlEncodedContentList.Add(parameter.ValidIdentifier);
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