using System.Text;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Builders;

internal class ModelBuilder : BaseBuilder
{
    private readonly IReadOnlyList<ModelDto> _models;

    public ModelBuilder(GeneratorSettings settings, IReadOnlyList<ModelDto> models) : base(settings)
    {
        _models = models;
    }

    public string Build(ModelDto restEaseModel, bool isFirst, bool isLast)
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

        if (extends.Any(e => e != null))
        {
            int skip = 0;
            if (Settings.ExtendClassForAnyOfAllOf)
            {
                var first = extends[0]!;
                var extendType = first.ArrayItemType == null
                    ? first.ToString()
                    : ArrayTypeMapper.Map(ArrayType.List, first.ArrayItemType); // Hack in case a class extends an array

                extendsClass = $" : {extendType}";
                skip = 1;
            }

            //foreach (var extend in extends.Skip(skip))
            //{
            //    var model = _models.FirstOrDefault(m => string.Equals(m.ClassName, extend?.Type, StringComparison.InvariantCultureIgnoreCase));
            //    if (model == null)
            //    {
            //        throw new InvalidOperationException($"Model with name '{extend}' is not found.");
            //    }

            //    foreach (var extraProperty in model.Properties)
            //    {
            //        if (!properties.Select(p => p.Name).Contains(extraProperty.Name))
            //        {
            //            properties.Add(extraProperty);
            //        }
            //    }
            //}
        }

        if (!Settings.SingleFile || isFirst)
        {
            builder.AppendLine($"namespace {AppendModelsNamespace(Settings.ModelsNamespace)}");
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

            //string propertyType;
            //if (property.ArrayItemType == null)
            //{
            //    propertyType = property.Type;
            //}
            //else
            //{
            //    propertyType = ArrayTypeMapper.Map(Settings.ArrayType, property.ArrayItemType); // Hack in case this property extends an array
            //}

            var safePropertyName = property.Name.ToValidIdentifier();
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