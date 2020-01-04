using System.Linq;
using System.Text;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGenerator.Builders
{
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
            builder.AppendLine("using System.Net.Http;");
            if (Settings.AddAuthorizationHeader)
            {
                builder.AppendLine("using System.Net.Http.Headers;");
            }
            builder.AppendLine("using System.Threading.Tasks;");
            builder.AppendLine("using RestEase;");
            if (hasModels || @interface.InlineModels.Any())
            {
                builder.AppendLine($"using {AppendModelsNamespace(@interface.Namespace)};");
            }
            builder.AppendLine();
            builder.AppendLine($"namespace {AppendApiNamespace(@interface.Namespace)}");
            builder.AppendLine("{");
            builder.AppendLine($"    public interface {@interface.Name}");
            builder.AppendLine("    {");
            if (Settings.AddAuthorizationHeader)
            {
                builder.AppendLine("        [Header(\"Authorization\")]");
                builder.AppendLine("        AuthenticationHeaderValue Authorization { get; set; }");
                builder.AppendLine();
            }

            foreach (var method in @interface.Methods)
            {
                string asyncPostfix = Settings.AppendAsync ? "Async" : string.Empty;

                builder.AppendLine("        /// <summary>");
                builder.AppendLine($"        /// {method.Summary.StripHtml()}");
                builder.AppendLine("        /// </summary>");
                foreach (var p in method.SummaryParameters)
                {
                    builder.AppendLine($"        /// {p}");
                }
                builder.AppendLine($"        {method.RestEaseAttribute}");

                foreach (var header in method.Headers)
                {
                    builder.AppendLine($"        {header}");
                }

                builder.AppendLine($"        {method.RestEaseMethod.ReturnType} {method.RestEaseMethod.Name}{asyncPostfix}({method.RestEaseMethod.ParametersAsString});");

                if (method != @interface.Methods.Last())
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