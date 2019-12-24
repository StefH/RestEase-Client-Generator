using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.OpenApi.Readers;
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

            var files = new List<GeneratedFile>();

            var @interface = new InterfaceMapper(settings).Map(openApiDocument.Paths);
            if (settings.SingleFile)
            {
                var singleFileBuilder = new StringBuilder(BuildInterface(@interface, settings));
                singleFileBuilder.AppendLine();
                var models = new ModelsMapper(settings).Map(openApiDocument.Components.Schemas);
                foreach (var modelCode in models.Select(m => BuildModel(m, settings)))
                {
                    singleFileBuilder.AppendLine(modelCode);
                }

                files.Add(new GeneratedFile
                {
                    Path = string.Empty,
                    Name = $"{settings.ApiName}.cs",
                    Content = singleFileBuilder.ToString()
                });
            }
            else
            {
                files.Add(new GeneratedFile
                {
                    Path = "Api",
                    Name = $"{@interface.Name}.cs",
                    Content = BuildInterface(@interface, settings)
                });

                var models = new ModelsMapper(settings).Map(openApiDocument.Components.Schemas);
                files.AddRange(models.Select(model => new GeneratedFile
                {
                    Path = "Models",
                    Name = $"{model.ClassName}.cs",
                    Content = BuildModel(model, settings)
                }));
            }

            return files;
        }

        #region Builders
        private static string BuildInterface(RestEaseInterface api, GeneratorSettings settings)
        {
            var builder = new StringBuilder();
            if (settings.ArrayType != ArrayType.Array)
            {
                builder.AppendLine("using System.Collections.Generic;");
            }
            builder.AppendLine("using System.Threading.Tasks;");
            builder.AppendLine("using RestEase;");
            builder.AppendLine($"using {api.Namespace}.Models;");
            builder.AppendLine();
            builder.AppendLine($"namespace {api.Namespace}.Api");
            builder.AppendLine("{");
            builder.AppendLine($"    public interface {api.Name}");
            builder.AppendLine("    {");
            foreach (var method in api.Methods)
            {
                builder.AppendLine("        /// <summary>");
                builder.AppendLine($"        /// {method.Summary}");
                builder.AppendLine("        /// </summary>");
                foreach (var p in method.SummaryParameters)
                {
                    builder.AppendLine($"        /// {p}");
                }
                builder.AppendLine($"        {method.RestEaseAttribute}");
                builder.AppendLine($"        Task{method.RestEaseMethod.ReturnType} {method.RestEaseMethod.Name}Async({method.RestEaseMethod.Parameters});");

                if (method != api.Methods.Last())
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
            if (!settings.SingleFile && settings.ArrayType != ArrayType.Array)
            {
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