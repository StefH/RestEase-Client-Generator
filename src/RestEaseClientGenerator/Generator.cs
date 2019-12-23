using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Utils;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator
{
    public class Generator : IGenerator
    {
        private static readonly CodeDomProvider CodeProvider = CodeDomProvider.CreateProvider("C#");

        //public interface IPetStoreApiExample
        //{
        //    /// <summary>
        //    /// List all pets
        //    /// </summary>
        //    /// <param name="limit">How many items to return at one time (max 100)</param>
        //    /// <returns>A paged array of pets</returns>
        //    [Get("{endpoint}/pets")]
        //    Task<Pet[]> Get(int? limit);
        //}

        public ICollection<GeneratedFile> FromStream(Stream stream, string clientNamespace, string apiName, out OpenApiDiagnostic diagnostic)
        {
            var reader = new OpenApiStreamReader();
            var openApiDocument = reader.Read(stream, out diagnostic);

            var files = new List<GeneratedFile>();

            var @interface = MapInterface(openApiDocument.Paths, apiName, clientNamespace);
            files.Add(new GeneratedFile
            {
                Path = "Api",
                Name = $"{@interface.Name}.cs",
                Content = BuildInterface(@interface)
            });

            var models = MapModels(openApiDocument.Components.Schemas, clientNamespace);
            files.AddRange(models.Select(model => new GeneratedFile
            {
                Path = "Models",
                Name = $"{model.ClassName}.cs",
                Content = BuildModel(model)
            }));

            return files;
        }

        #region Models
        private static IEnumerable<RestEaseModel> MapModels(IDictionary<string, OpenApiSchema> schemas, string ns)
        {
            return schemas.Where(s => s.Value.GetSchemaType() == SchemaType.Object).Select(x => new RestEaseModel
            {
                NameSpace = ns,
                ClassName = x.Key.ToPascalCase(),
                Properties = MapSchema(x.Value, x.Key, x.Value.Nullable) as ICollection<string>
            });
        }

        private static object MapSchema(OpenApiSchema schema, string name, bool isNullable, bool pascalCase = true)
        {
            if (schema == null)
            {
                return null;
            }

            string nameCamelCase = string.IsNullOrEmpty(name) ? "" : $" {(pascalCase ? name.ToPascalCase() : name)}";
            string nullable = isNullable ? "?" : string.Empty;

            switch (schema.GetSchemaType())
            {
                case SchemaType.Array:
                    switch (schema.Items.GetSchemaType())
                    {
                        case SchemaType.Object:
                            return schema.Items.Reference != null ? $"{schema.Items.Reference.Id}[]{nameCamelCase}" : $"object[]{nameCamelCase}";

                        case SchemaType.Unknown:
                            return $"object[]{nameCamelCase}";

                        default:
                            return $"{MapSchema(schema.Items, null, schema.Items.Nullable)}[]{nameCamelCase}";
                    }

                case SchemaType.Boolean:
                    return $"bool{nullable}{nameCamelCase}";

                case SchemaType.Integer:
                    switch (schema.GetSchemaFormat())
                    {
                        case SchemaFormat.Int64:
                            return $"long{nullable}{nameCamelCase}";

                        default:
                            return $"int{nullable}{nameCamelCase}";
                    }

                case SchemaType.Number:
                    switch (schema.GetSchemaFormat())
                    {
                        case SchemaFormat.Float:
                            return $"float{nullable}{nameCamelCase}";

                        default:
                            return $"double{nullable}{nameCamelCase}";
                    }

                case SchemaType.String:
                    switch (schema.GetSchemaFormat())
                    {
                        case SchemaFormat.DateTime:
                            return $"DateTime{nullable}{nameCamelCase}";

                        default:
                            return $"string{nameCamelCase}";
                    }

                case SchemaType.Object:
                    var list = new List<string>();

                    foreach (var schemaProperty in schema.Properties)
                    {
                        var openApiSchema = schemaProperty.Value;
                        if (openApiSchema.GetSchemaType() == SchemaType.Object)
                        {
                            string objectName = pascalCase ? schemaProperty.Key.ToPascalCase() : schemaProperty.Key;
                            string objectType = openApiSchema.Reference != null ? openApiSchema.Reference.Id.ToPascalCase().Replace(" ", "") : "object";

                            list.Add($"{objectType} {objectName}");
                        }
                        else
                        {
                            var property = MapSchema(openApiSchema, schemaProperty.Key, openApiSchema.Nullable);
                            if (property != null && property is string propertyAsString)
                            {
                                list.Add(propertyAsString);
                            }
                        }
                    }

                    return list;

                default:
                    return null;
            }
        }
        #endregion

        #region Interface
        private static RestEaseInterface MapInterface(OpenApiPaths paths, string name, string ns)
        {
            var methods = paths.Select(p => MapPath(p.Key, p.Value)).SelectMany(x => x).ToList();

            //var counts = methods
            //    .GroupBy(method => method.RestEaseMethod.Name + method.RestEaseMethod.Parameters)
            //    .Where(grouping => grouping.Count() > 1)
            //    .ToDictionary(grouping => grouping.Key, p => p.Count());

            //// modify the list, going backwards so we can take advantage of our counts.
            //for (int i = methods.Count - 1; i >= 0; i--)
            //{
            //    string key = methods[i].RestEaseMethod.Name + methods[i].RestEaseMethod.Parameters;
            //    if (counts.ContainsKey(key))
            //    {
            //        // add the suffix and decrement the number of duplicates left to tag.
            //        methods[i].RestEaseMethod.Name += $"{counts[key]--}";
            //    }
            //}

            return new RestEaseInterface
            {
                Name = $"I{name}Api",
                NameSpace = ns,
                Methods = methods
            };
        }

        private static IEnumerable<RestEaseInterfaceMethodDetails> MapPath(string path, OpenApiPathItem pathItem)
        {
            return pathItem.Operations.Select(o => MapOperationToMappingModel(path, o.Key.ToString(), o.Value));
        }

        private static string GenerateNameForMethod(string path, string httpMethodPascalCased)
        {
            var list = new List<string> { httpMethodPascalCased };

            bool byFound = false;
            foreach (string part in path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (part.StartsWith("{"))
                {
                    var text = part.Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries)[0].ToPascalCase();

                    list.Add(byFound ? $"By{text}" : $"And{text}");

                    byFound = true;
                }
                else
                {
                    list.Add(part.ToPascalCase());
                }
            }

            return string.Join("", list);
        }

        private static bool TryGetOpenApiMediaType(IDictionary<string, OpenApiMediaType> content, out OpenApiMediaType mediaType)
        {
            if (content.TryGetValue("application/json", out mediaType))
            {
                return true;
            }

            var jsonKey = content.Keys.FirstOrDefault(key => key.Contains("application/json"));
            if (jsonKey != null)
            {
                mediaType = content[jsonKey];
                return true;
            }

            if (content.Count > 0)
            {
                mediaType = content.First().Value;
                return true;
            }

            return false;
        }

        private static RestEaseInterfaceMethodDetails MapOperationToMappingModel(string path, string httpMethod, OpenApiOperation operation)
        {
            string methodRestEaseForAnnotation = httpMethod.ToPascalCase();
            string methodRestEaseMethod = !string.IsNullOrEmpty(operation.OperationId) ?
                operation.OperationId.ToPascalCase() :
                GenerateNameForMethod(path, methodRestEaseForAnnotation);

            var pathParameterList = operation.Parameters
                .Where(p => p.In == ParameterLocation.Path && p.Schema.GetSchemaType() != SchemaType.Object)
                .Select(p => $"[Path] {MapSchema(p.Schema, p.Name, !p.Required, false)}")
                .ToList();

            var queryParameterList = operation.Parameters
                .Where(p => p.In == ParameterLocation.Query && p.Schema.GetSchemaType() != SchemaType.Object)
                .Select(p => $"[Query] {MapSchema(p.Schema, CodeProvider.CreateValidIdentifier(p.Name), !p.Required, false)}")
                .ToList();

            var bodyParameterList = new List<string>();
            if (operation.RequestBody != null && TryGetOpenApiMediaType(operation.RequestBody.Content, out OpenApiMediaType requestMediaType))
            {
                string bodyParameter;
                switch (requestMediaType.Schema?.GetSchemaType())
                {
                    case SchemaType.Array:
                        string arrayType = requestMediaType.Schema.Items.Reference != null ? requestMediaType.Schema.Items.Reference.Id : MapSchema(requestMediaType.Schema.Items, "", requestMediaType.Schema.Nullable).ToString();
                        bodyParameter = $"{arrayType}[]";
                        break;

                    case SchemaType.Object:
                        bodyParameter = requestMediaType.Schema.Reference.Id;
                        break;

                    default:
                        bodyParameter = "";
                        break;
                }

                if (!string.IsNullOrEmpty(bodyParameter))
                {
                    bodyParameterList.Add($"[Body] {bodyParameter} {bodyParameter.ToCamelCase()}");
                }
            }

            var methodParameterList = pathParameterList.Union(bodyParameterList).Union(queryParameterList);

            var response = operation.Responses.First();

            string returnType = "";
            if (response.Value != null && TryGetOpenApiMediaType(response.Value.Content, out OpenApiMediaType responseMediaType))
            {
                switch (responseMediaType.Schema?.GetSchemaType())
                {
                    case SchemaType.Array:
                        string arrayType = responseMediaType.Schema.Items.Reference != null ?
                            responseMediaType.Schema.Items.Reference.Id :
                            MapSchema(responseMediaType.Schema.Items, "", responseMediaType.Schema.Nullable).ToString();
                        returnType = $"<{arrayType}[]>";
                        break;

                    case SchemaType.Object:
                        returnType = responseMediaType.Schema.Reference != null ?
                            $"<{responseMediaType.Schema.Reference.Id}>" :
                            $"<{MapSchema(responseMediaType.Schema.AdditionalProperties, "", responseMediaType.Schema.AdditionalProperties.Nullable, false)}>";
                        break;
                }
            }

            var method = new RestEaseInterfaceMethodDetails
            {
                RestEaseAttribute = $"[{methodRestEaseForAnnotation}(\"{{endpoint}}{path}\")]",
                RestEaseMethod = new RestEaseInterfaceMethod
                {
                    ReturnType = returnType,
                    Name = methodRestEaseMethod,
                    Parameters = string.Join(", ", methodParameterList)
                }
            };

            return method;
        }
        #endregion

        #region Builders
        private static string BuildModel(RestEaseModel restEaseModel)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"namespace {restEaseModel.NameSpace}.Models");
            builder.AppendLine("{");
            builder.AppendLine($"    public class {restEaseModel.ClassName}");
            builder.AppendLine("    {");
            foreach (var property in restEaseModel.Properties)
            {
                builder.AppendLine($"        public {property} {{ get; set; }}");
                builder.AppendLine();
            }
            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }

        private static string BuildInterface(RestEaseInterface api)
        {
            var builder = new StringBuilder();
            builder.AppendLine("using System.Threading.Tasks;");
            builder.AppendLine("using RestEase;");
            builder.AppendLine($"using {api.NameSpace}.Models;");
            builder.AppendLine();
            builder.AppendLine($"namespace {api.NameSpace}.Api");
            builder.AppendLine("{");
            builder.AppendLine($"    public interface {api.Name}");
            builder.AppendLine("    {");
            builder.AppendLine("        [Path(\"endpoint\", UrlEncode = false)]");
            builder.AppendLine("        string Endpoint { get; set; }");
            builder.AppendLine();
            foreach (var method in api.Methods)
            {
                builder.AppendLine($"        {method.RestEaseAttribute}");
                builder.AppendLine($"        Task{method.RestEaseMethod.ReturnType} {method.RestEaseMethod.Name}Async({method.RestEaseMethod.Parameters});");
                builder.AppendLine();
            }
            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }
        #endregion
    }
}