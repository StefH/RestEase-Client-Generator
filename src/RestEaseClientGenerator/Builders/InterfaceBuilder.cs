using System.Text;
using Flurl;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGenerator.Builders;

internal class InterfaceBuilder : BaseBuilder
{
    public InterfaceBuilder(GeneratorSettings settings) : base(settings)
    {
    }

    public string Build(RestEaseInterface @interface, bool hasModels)
    {
        var builder = new StringBuilder();
        builder.AppendLine("using System;");
        builder.AppendLine("using System.Collections.Generic;");
        builder.AppendLine("using System.IO;");
        builder.AppendLine("using System.Net.Http;");
        builder.AppendLine("using System.Net.Http.Headers;");
        builder.AppendLine("using System.Threading.Tasks;");
        builder.AppendLine("using AnyOfTypes;");
        builder.AppendLine("using RestEase;");
        if (hasModels || @interface.ExtraModels.Any())
        {
            builder.AppendLine($"using {AppendModelsNamespace(@interface.Namespace)};");
        }
        builder.AppendLine();
        builder.AppendLine($"namespace {AppendApiNamespace(@interface.Namespace)}");
        builder.AppendLine("{");
        builder.AppendLine("    /// <summary>");
        builder.AppendLine($"    /// {@interface.Summary.StripHtml()}");
        builder.AppendLine("    /// </summary>");
        builder.AppendLine($"    public interface {@interface.Name}");
        builder.AppendLine("    {");

        foreach (var header in @interface.VariableHeaders)
        {
            builder.AppendLine(header.Value != null
                ? $"        [Header(\"{header.Name}\", \"{header.Value}\")]"
                : $"        [Header(\"{header.Name}\")]");

            builder.AppendLine($"        string {header.ValidIdentifier} {{ get; set; }}");
            builder.AppendLine();
        }

        Url url = string.Empty;
        foreach (var query in @interface.ConstantQueryParameters.Where(p => p.Value != null))
        {
            url = url.SetQueryParam(query.Name, query.Value);
        }
        var appendPath = url.ToString();

        foreach (var query in @interface.ConstantQueryParameters.Where(p => p.Value is null))
        {
            builder.AppendLine($"        [Query(\"{query.Name}\")]");
            builder.AppendLine($"        {query.IdentifierWithType} {{ get; set; }}");
            builder.AppendLine();
        }

        foreach (var method in @interface.Methods)
        {
            string asyncPostfix = Settings.AppendAsync ? "Async" : string.Empty;

            builder.AppendLine("        /// <summary>");
            if (method.Summary != null)
            {
                builder.AppendLine($"        /// {method.Summary.StripHtml()}");
                builder.AppendLine("        ///");
            }

            builder.AppendLine($"        /// {method.Path}");
            builder.AppendLine("        /// </summary>");
            foreach (var sp in method.SummaryParameters)
            {
                builder.AppendLine($"        /// <param name=\"{sp.ValidIdentifier}\">{sp.Summary.StripHtml()}</param>");
            }

            var path = $"{method.RestEaseAttribute.Path}{appendPath}";
            builder.AppendLine($"        [{method.RestEaseAttribute.Method}(\"{path}\")]");

            foreach (var header in method.Headers)
            {
                builder.AppendLine($"        {header}");
            }

            string paramsAsString = string.Join(", ", method.RestEaseMethod.Parameters.Select(mp => mp.IdentifierWithRestEase));
            builder.AppendLine($"        {method.RestEaseMethod.ReturnType} {method.RestEaseMethod.Name}{asyncPostfix}({paramsAsString});");

            if (method != @interface.Methods.Last())
            {
                builder.AppendLine();
            }
        }
        builder.AppendLine("    }");
        builder.Append("}");

        return builder.ToString();
    }
}