using System.Linq;
using System.Text;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGenerator.Builders
{
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

            builder.AppendLine($"namespace {AppendModelsNamespace(restEaseModel.Namespace)}");
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
    }
}