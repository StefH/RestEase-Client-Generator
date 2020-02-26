using System.Linq;
using System.Text;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGenerator.Builders
{
    internal class EnumBuilder : BaseBuilder
    {
        public EnumBuilder(GeneratorSettings settings) : base(settings)
        {
        }

        public string Build(RestEaseEnum restEaseEnum)
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
            builder.AppendLine($"    public enum {restEaseEnum.EnumName}");
            builder.AppendLine("    {");
            builder.AppendLine(string.Join(",\n", restEaseEnum.Values.Select(enumValue => $"        {enumValue}")));
            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }
    }
}