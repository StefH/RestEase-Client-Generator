using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Builders
{
    internal class InterfaceBuilder : BaseBuilder
    {
        public InterfaceBuilder(GeneratorSettings settings) : base(settings)
        {
        }

        public string Build(RestEaseInterface @interface, RestEaseSecurity security, bool hasModels)
        {
            var builder = new StringBuilder();
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using System.Net.Http;");
            builder.AppendLine("using System.Net.Http.Headers;");
            builder.AppendLine("using System.Threading.Tasks;");
            builder.AppendLine("using RestEase;");
            if (hasModels || @interface.InlineModels.Any())
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

            var headers = new Dictionary<string, string>();
            if (security != null && Settings.PreferredSecurityDefinitionType != SecurityDefinitionType.None)
            {
                var header = security.Definitions.FirstOrDefault(sd => sd.Type == SecurityDefinitionType.Header);
                // var query = security.Definitions.FirstOrDefault(sd => sd.Type == SecurityDefinitionType.Query);

                if (header != null &&
                    (Settings.PreferredSecurityDefinitionType == SecurityDefinitionType.Automatic || Settings.PreferredSecurityDefinitionType == SecurityDefinitionType.Header))
                {
                    if (!headers.ContainsKey(header.IdentifierName))
                    {
                        headers.Add(header.IdentifierName, header.Name);
                    }
                }
            }
            foreach (var header in @interface.VariableInterfaceHeaders)
            {
                string key = header.ValidIdentifier.ToPascalCase();
                if (!headers.ContainsKey(key))
                {
                    headers.Add(key, header.Identifier);
                }
            }

            foreach (var header in headers)
            {
                builder.AppendLine($"        [Header(\"{header.Value}\")]");
                builder.AppendLine($"        string {header.Key} {{ get; set; }}");
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

                string paramsAsString = string.Join(", ", method.RestEaseMethod.Parameters.Select(mp => mp.IdentifierWithRestEase));
                builder.AppendLine($"        {method.RestEaseMethod.ReturnType} {method.RestEaseMethod.Name}{asyncPostfix}({paramsAsString});");

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