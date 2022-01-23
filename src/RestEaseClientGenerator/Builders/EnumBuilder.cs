using System.Text;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Builders;

internal class EnumBuilder : BaseBuilder
{
    public EnumBuilder(GeneratorSettings settings) : base(settings)
    {
    }

    public string Build(RestEaseEnum restEaseEnum)
    {
        if (Settings.PreferredEnumType == EnumType.Enum)
        {
            return BuildAsEnum(restEaseEnum);
        }

        return BuildAsString(restEaseEnum);
    }

    private string BuildAsEnum(RestEaseEnum restEaseEnum)
    {
        var builder = new StringBuilder();
        if (!Settings.SingleFile)
        {
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine();
        }

        builder.AppendLine($"namespace {AppendModelsNamespace(restEaseEnum.Namespace)}");
        builder.AppendLine("{");

        if (!string.IsNullOrEmpty(restEaseEnum.Description))
        {
            builder.AppendLine("    /// <summary>");
            builder.AppendLine($"    /// {restEaseEnum.Description.StripHtml()}");
            builder.AppendLine("    /// </summary>");
        }

        builder.AppendLine($"    public enum {restEaseEnum.EnumName}");
        builder.AppendLine("    {");
        builder.AppendLine(string.Join(",\r\n", restEaseEnum.Values.Select(enumValue => $"        {enumValue}")));
        builder.AppendLine("    }");
        builder.AppendLine("}");

        return builder.ToString();
    }

    private string BuildAsString(RestEaseEnum restEaseEnum)
    {
        var builder = new StringBuilder();
        var values = restEaseEnum.Values.Select(value => new
        {
            name = CSharpUtils.CreateValidIdentifier(value, CasingType.Pascal),
            value
        });

        builder.AppendLine($"namespace {AppendModelsNamespace(restEaseEnum.Namespace)}");
        builder.AppendLine("{");

        if (!string.IsNullOrEmpty(restEaseEnum.Description))
        {
            builder.AppendLine("    /// <summary>");
            builder.AppendLine($"    /// {restEaseEnum.Description.StripHtml()}");
            builder.AppendLine("    /// </summary>");
        }

        builder.AppendLine($"    public static class {restEaseEnum.EnumName}");
        builder.AppendLine("    {");
        builder.AppendLine(string.Join("\r\n", values.Select(x => $"        public const string {x.name} = \"{x.value}\";")));
        builder.AppendLine("    }");
        builder.AppendLine("}");

        return builder.ToString();
    }
}