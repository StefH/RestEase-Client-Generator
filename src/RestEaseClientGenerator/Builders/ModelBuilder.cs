using System.Text;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGenerator.Builders;

internal class ModelBuilder : BaseBuilder
{
    public ModelBuilder(GeneratorSettings settings) : base(settings)
    {
    }

    public string Build(RestEaseModel restEaseModel)
    {
        var builder = new StringBuilder();
        if (!Settings.SingleFile)
        {
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine();
        }

        string extendsClass = string.Empty;
        if (restEaseModel.Properties.Any(p => p.Extends is not null))
        {
            var extends = restEaseModel.Properties.Where(p => p.Extends is not null).Select(p => p.Extends);
            extendsClass = $" : {string.Join(", ", extends)}";
        }

        builder.AppendLine($"namespace {AppendModelsNamespace(restEaseModel.Namespace)}");
        builder.AppendLine("{");

        if (!string.IsNullOrEmpty(restEaseModel.Description))
        {
            builder.AppendLine("    /// <summary>");
            builder.AppendLine($"    /// {restEaseModel.Description.StripHtml()}");
            builder.AppendLine("    /// </summary>");
        }

        builder.AppendLine($"    public class {restEaseModel.ClassName}{extendsClass}");
        builder.AppendLine("    {");
        foreach (var property in restEaseModel.Properties.Where(p => p.Extends is null))
        {
            if (!string.IsNullOrEmpty(property.Description))
            {
                builder.AppendLine("        /// <summary>");
                builder.AppendLine($"        /// {property.Description.StripHtml()}");
                builder.AppendLine("        /// </summary>");
            }

            if (property.Name == restEaseModel.ClassName)
            {
                builder.AppendLine($"        [Newtonsoft.Json.JsonProperty(\"{property.Name}\")]");
                builder.AppendLine($"        public {property}_ {{ get; set; }}");
            }
            else
            {
                builder.AppendLine($"        public {property} {{ get; set; }}");
            }

            if (property != restEaseModel.Properties.Last())
            {
                builder.AppendLine();
            }
        }
        builder.AppendLine("    }");
        builder.Append("}");

        return builder.ToString();
    }
}