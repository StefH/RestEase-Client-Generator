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

    public string Build(ModelDto modelDto, bool isFirst, bool isLast)
    {
        if (modelDto.Name == "AccountSasParameters")
        {
            int x = 8;
        }

        var builder = new StringBuilder();
        if (!Settings.SingleFile)
        {
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine();
        }

        var properties = modelDto.Properties.ToList();

        string extendsClass = string.Empty;
        
        if (modelDto.Extends?.Any() == true)
        {
            int skip = 0;
            if (Settings.ExtendClassForAnyOfAllOf)
            {
                var first = modelDto.Extends[0];
                //var extendType = first.ArrayItemType == null
                //    ? first.ToString()
                //    : ArrayTypeMapper.Map(ArrayType.List, first.ArrayItemType); // Hack in case a class extends an array

                extendsClass = $" : {first.Type}";
                skip = 1;
            }

            foreach (var extend in modelDto.Extends.Skip(skip))
            {
                var model = _models.FirstOrDefault(m => string.Equals(m.Name, extend?.Type, StringComparison.InvariantCultureIgnoreCase));
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
            builder.AppendLine($"namespace {AppendModelsNamespace(Settings.Namespace)}");
            builder.AppendLine("{");
        }

        if (!string.IsNullOrEmpty(modelDto.Description))
        {
            builder.AppendLine("    /// <summary>");
            builder.AppendLine($"    /// {modelDto.Description.StripHtml()}");
            builder.AppendLine("    /// </summary>");
        }

        if (Settings.AddFluentBuilder)
        {
            builder.AppendLine("    [FluentBuilder.AutoGenerateBuilder]");
        }

        builder.AppendLine($"    public class {modelDto.Name}{extendsClass}");
        builder.AppendLine("    {");
        foreach (var property in properties)
        {
            if (!string.IsNullOrEmpty(property.Description))
            {
                builder.AppendLine("        /// <summary>");
                builder.AppendLine($"        /// {property.Description.StripHtml()}");
                builder.AppendLine("        /// </summary>");
            }

            string propertyType;
            //if (property is EnumDto @enum)
            //{

            //}
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
                if (safePropertyName == modelDto.Name)
                {
                    builder.AppendLine($"        [Newtonsoft.Json.JsonProperty(\"{safePropertyName}\")]");
                    builder.AppendLine($"        public {property.Type} {safePropertyName}_ {{ get; set; }}");
                }
                else
                {
                    builder.AppendLine($"        public {property.Type} {safePropertyName} {{ get; set; }}");
                }
            }

            if (property != modelDto.Properties.Last())
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