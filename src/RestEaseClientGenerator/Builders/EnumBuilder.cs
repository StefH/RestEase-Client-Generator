using System.Text;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Types.Internal;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Builders;

internal class EnumBuilder : BaseBuilder
{
    public EnumBuilder(GeneratorSettings settings) : base(settings)
    {
    }

    public string Build(RestEaseEnum restEaseEnum, bool isFirst, bool isLast)
    {
        if (Settings.PreferredEnumType == EnumType.Enum)
        {
            return BuildAsEnum(restEaseEnum, isFirst, isLast);
        }

        return BuildAsString(restEaseEnum, isFirst, isLast);
    }

    private string BuildAsEnum(RestEaseEnum restEaseEnum, bool isFirst, bool isLast)
    {
        var builder = new StringBuilder();
        if (!Settings.SingleFile)
        {
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine();
        }

        if (!Settings.SingleFile || isFirst)
        {
            builder.AppendLine($"namespace {AppendModelsNamespace(restEaseEnum.Namespace)}");
            builder.AppendLine("{");
        }

        if (!string.IsNullOrEmpty(restEaseEnum.Description))
        {
            builder.AppendLine("    /// <summary>");
            builder.AppendLine($"    /// {restEaseEnum.Description.StripHtml()}");
            builder.AppendLine("    /// </summary>");
        }

        var safeValues = restEaseEnum.Values.Select(IdentifierUtils.CreateValidEnumMember);

        builder.AppendLine($"    public enum {restEaseEnum.EnumName}");
        builder.AppendLine("    {");
        builder.AppendLine(string.Join(",\r\n", safeValues.Select(enumValue => $"        {enumValue}")));
        builder.AppendLine("    }");

        if (!Settings.SingleFile || isLast)
        {
            builder.AppendLine("}");
        }

        return builder.ToString();
    }

    private string BuildAsString(RestEaseEnum restEaseEnum, bool isFirst, bool isLast)
    {
        var builder = new StringBuilder();

        var values = restEaseEnum.Values.Select(value => new
        {
            name = IdentifierUtils.CreateValidEnumMember(value),
            value
        });

        if (!Settings.SingleFile || isFirst)
        {
            builder.AppendLine($"namespace {AppendModelsNamespace(restEaseEnum.Namespace)}");
            builder.AppendLine("{");
        }

        if (!string.IsNullOrEmpty(restEaseEnum.Description))
        {
            builder.AppendLine("    /// <summary>");
            builder.AppendLine($"    /// {restEaseEnum.Description.StripHtml()}");
            builder.AppendLine("    /// </summary>");
        }

        builder.AppendLine($"    public static class {restEaseEnum.EnumName}");
        builder.AppendLine("    {");
        builder.AppendLine(string.Join("\r\n\r\n", values.Select(x => $"        public const string {x.name} = \"{x.value}\";")));
        builder.AppendLine("    }");

        if (!Settings.SingleFile || isLast)
        {
            builder.AppendLine("}");
        }

        return builder.ToString();
    }
}