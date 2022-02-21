using System.Text;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGenerator.Builders;

internal class ModelBuilder : BaseBuilder
{
    private readonly IReadOnlyList<RestEaseModel> _models;

    public ModelBuilder(GeneratorSettings settings, IReadOnlyList<RestEaseModel> models) : base(settings)
    {
        _models = models;
    }

    public string Build(RestEaseModel restEaseModel, bool isFirst, bool isLast)
    {
        var builder = new StringBuilder();
        if (!Settings.SingleFile)
        {
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine();
        }

        var properties = restEaseModel.Properties.Where(p => p.Extends is null).ToList();

        string extendsClass = string.Empty;
        var extends = restEaseModel.Properties.Where(p => p.Extends is not null).Select(p => p.Extends).ToList();

        if (extends.Any())
        {
            int skip = 0;
            if (Settings.ExtendClassForAnyOfAllOf)
            {
                extendsClass = $" : {extends[0]}";
                skip = 1;
            }
            
            foreach (var extend in extends.Skip(skip))
            {
                var model = _models.FirstOrDefault(m => string.Equals(m.ClassName, extend, StringComparison.InvariantCultureIgnoreCase));
                if (model == null)
                {
                    throw new InvalidOperationException($"Model with name '{extend}' is not found.");
                }

                foreach (var extraProperty in model.Properties)
                {
                    if (!properties.Select(p => p.Name).Contains(extraProperty.Name))
                    {
                        properties.Add(extraProperty);
                    }
                }
            }
        }

        if (!Settings.SingleFile || isFirst)
        {
            builder.AppendLine($"namespace {AppendModelsNamespace(restEaseModel.Namespace)}");
            builder.AppendLine("{");
        }

        if (!string.IsNullOrEmpty(restEaseModel.Description))
        {
            builder.AppendLine("    /// <summary>");
            builder.AppendLine($"    /// {restEaseModel.Description.StripHtml()}");
            builder.AppendLine("    /// </summary>");
        }

        if (Settings.AddFluentBuilder)
        {
            builder.AppendLine("    [FluentBuilder.AutoGenerateBuilder]");
        }

        builder.AppendLine($"    public class {restEaseModel.ClassName}{extendsClass}");
        builder.AppendLine("    {");
        foreach (var property in properties)
        {
            if (!string.IsNullOrEmpty(property.Description))
            {
                builder.AppendLine("        /// <summary>");
                builder.AppendLine($"        /// {property.Description.StripHtml()}");
                builder.AppendLine("        /// </summary>");
            }

            var safePropertyName = !string.IsNullOrEmpty(property.Name)
                ? property.Name.ToValidIdentifier()
                : string.Empty;

            if (safePropertyName != property.Name)
            {
                builder.AppendLine($"        [Newtonsoft.Json.JsonProperty(\"{property.Name}\")]");
                builder.AppendLine($"        public {property.Type} {safePropertyName} {{ get; set; }}");
            }
            else
            {
                if (safePropertyName == restEaseModel.ClassName)
                {
                    builder.AppendLine($"        [Newtonsoft.Json.JsonProperty(\"{safePropertyName}\")]");
                    builder.AppendLine($"        public {property.Type} {safePropertyName}_ {{ get; set; }}");
                }
                else
                {
                    builder.AppendLine($"        public {property.Type} {safePropertyName} {{ get; set; }}");
                }
            }

            if (property != restEaseModel.Properties.Last())
            {
                builder.AppendLine();
            }
        }
        builder.AppendLine("    }");

        if (!Settings.SingleFile || isLast)
        {
            builder.Append("}");
        }

        return builder.ToString();
    }
}