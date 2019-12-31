using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Constants;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Mappers;
using RestEaseClientGenerator.Models;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator
{
    public class Generator : IGenerator
    {
        public ICollection<GeneratedFile> FromStream(Stream stream, string clientNamespace, string apiName, out OpenApiDiagnostic diagnostic)
        {
            return FromStream(stream, new GeneratorSettings
            {
                Namespace = clientNamespace,
                ApiName = apiName
            }, out diagnostic);
        }

        public ICollection<GeneratedFile> FromStream(Stream stream, GeneratorSettings settings, out OpenApiDiagnostic diagnostic)
        {
            var reader = new OpenApiStreamReader();
            var openApiDocument = reader.Read(stream, out diagnostic);

            var models = new ModelsMapper(settings).Map(openApiDocument.Components.Schemas).ToList();
            var @interface = new InterfaceMapper(settings).Map(openApiDocument);

            var files = new List<GeneratedFile>
            {
                // Add Interface
                new GeneratedFile
                {
                    Path = "Api", Name = $"{@interface.Name}.cs", Content = BuildInterface(@interface, settings, models.Any())
                }
            };

            var extensions = BuildExtensions(@interface, @interface.Name, settings);
            if (extensions != null)
            {
                // Add ApiExtension
                files.Add(new GeneratedFile
                {
                    Path = "Api",
                    Name = $"{new string(@interface.Name.Skip(1).ToArray())}Extensions.cs",
                    Content = extensions
                });
            }

            // Add Models
            files.AddRange(models.Select(model => new GeneratedFile
            {
                Path = "Models",
                Name = $"{model.ClassName}.cs",
                Content = BuildModel(model, settings)
            }));

            // Add Inline Models
            files.AddRange(@interface.InlineModels.Select(model => new GeneratedFile
            {
                Path = "Models",
                Name = $"{model.ClassName}.cs",
                Content = BuildModel(model, settings)
            }));

            if (settings.SingleFile)
            {
                return new[] { new GeneratedFile
                {
                    Path = string.Empty,
                    Name = $"{@interface.Name}.cs",
                    Content = string.Join("\r\n", files.Select(f => f.Content))
                }};
            }

            return files;
        }

        #region Builders
        private static string BuildExtensions(RestEaseInterface api, string apiName, GeneratorSettings settings)
        {
            var methods = api.Methods
                .Where(m => m.ExtensionMethodDetails != null)
                .ToList();

            if (!methods.Any())
            {
                return null;
            }

            var builder = new StringBuilder();
            if (!settings.SingleFile)
            {
                builder.AppendLine("using System;");
                builder.AppendLine("using System.Collections.Generic;");
                builder.AppendLine("using System.Net.Http;");
                builder.AppendLine("using System.Threading.Tasks;");
                builder.AppendLine("using RestEase;");
                builder.AppendLine($"using {api.Namespace}.Models;");
            }

            builder.AppendLine();
            builder.AppendLine($"namespace {api.Namespace}.Api");
            builder.AppendLine("{");
            builder.AppendLine($"    public static class {new string(apiName.Skip(1).ToArray())}Extensions");
            builder.AppendLine("    {");

            foreach (var method in methods)
            {
                string asyncPostfix = settings.AppendAsync ? "Async" : string.Empty;

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
                        BuildMultipartFormDataExtensionMethodBody(settings, builder, method);
                        break;

                    case SupportedContentTypes.ApplicationFormUrlEncoded:
                        BuildApplicationFormUrlEncodedExtensionMethodBody(settings, builder, method);
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
                        switch (settings.MultipartFormDataFileType)
                        {
                            case MultipartFormDataFileType.Stream:
                                builder.AppendLine(
                                    $"            var {parameter.Identifier}Content = new StreamContent({parameter.Identifier});");
                                break;

                            default:
                                builder.AppendLine(
                                    $"            var {parameter.Identifier}Content = new ByteArrayContent({parameter.Identifier});");
                                break;
                        }

                        builder.AppendLine($"            content.Add({parameter.Identifier}Content);");
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

        private static string BuildInterface(RestEaseInterface @interface, GeneratorSettings settings, bool hasModels)
        {
            var builder = new StringBuilder();
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using System.Net.Http;");
            if (settings.AddAuthorizationHeader)
            {
                builder.AppendLine("using System.Net.Http.Headers;");
            }
            builder.AppendLine("using System.Threading.Tasks;");
            builder.AppendLine("using RestEase;");
            if (hasModels || @interface.InlineModels.Any())
            {
                builder.AppendLine($"using {@interface.Namespace}.Models;");
            }
            builder.AppendLine();
            builder.AppendLine($"namespace {@interface.Namespace}.Api");
            builder.AppendLine("{");
            builder.AppendLine($"    public interface {@interface.Name}");
            builder.AppendLine("    {");
            if (settings.AddAuthorizationHeader)
            {
                builder.AppendLine("        [Header(\"Authorization\")]");
                builder.AppendLine("        AuthenticationHeaderValue Authorization { get; set; }");
                builder.AppendLine();
            }
            foreach (var method in @interface.Methods)
            {
                string asyncPostfix = settings.AppendAsync ? "Async" : string.Empty;

                builder.AppendLine("        /// <summary>");
                builder.AppendLine($"        /// {method.Summary.StripHtml()}");
                builder.AppendLine("        /// </summary>");
                foreach (var p in method.SummaryParameters)
                {
                    builder.AppendLine($"        /// {p}");
                }
                builder.AppendLine($"        {method.RestEaseAttribute}");
                builder.AppendLine($"        {method.RestEaseMethod.ReturnType} {method.RestEaseMethod.Name}{asyncPostfix}({method.RestEaseMethod.ParametersAsString});");

                if (method != @interface.Methods.Last())
                {
                    builder.AppendLine();
                }
            }
            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }

        private static string BuildModel(RestEaseModel restEaseModel, GeneratorSettings settings)
        {
            var builder = new StringBuilder();
            if (!settings.SingleFile)
            {
                builder.AppendLine("using System;");
                builder.AppendLine("using System.Collections.Generic;");
                builder.AppendLine();
            }

            builder.AppendLine($"namespace {restEaseModel.Namespace}.Models");
            builder.AppendLine("{");
            builder.AppendLine($"    public class {restEaseModel.ClassName}");
            builder.AppendLine("    {");
            foreach (var property in restEaseModel.Properties)
            {
                builder.AppendLine($"        public {property} {{ get; set; }}");
                if (property != restEaseModel.Properties.Last())
                {
                    builder.AppendLine();
                }
            }
            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }
        #endregion
    }
}