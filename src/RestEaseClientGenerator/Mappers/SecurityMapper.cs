using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Mappers
{
    internal class SecurityMapper : BaseMapper
    {
        public SecurityMapper(GeneratorSettings settings) : base(settings)
        {
        }

        public RestEaseSecurity Map(OpenApiDocument openApiDocument)
        {
            if (openApiDocument.SecurityRequirements != null && openApiDocument.SecurityRequirements.Any())
            {
                return MapSwaggerVersion2(openApiDocument);
            }

            if (openApiDocument.Components?.SecuritySchemes != null)
            {
                return MapOpenApiVersion3(openApiDocument);
            }

            return null;
        }

        private RestEaseSecurity MapOpenApiVersion3(OpenApiDocument openApiDocument)
        {
            if (openApiDocument.Components.SecuritySchemes.TryGetValue("api_key", out var openApiSecurityScheme))
            {
                return new RestEaseSecurity
                {
                    Definitions = Map(new[] { openApiSecurityScheme }),
                    SecurityVersionType = SecurityVersionType.OpenApi3
                };
            }

            return null;
        }

        private RestEaseSecurity MapSwaggerVersion2(OpenApiDocument openApiDocument)
        {
            var openApiSecuritySchemes = openApiDocument.SecurityRequirements
                .Select(sr => sr.Keys.FirstOrDefault())
                .Where(k => k != null);

            return new RestEaseSecurity
            {
                Definitions = Map(openApiSecuritySchemes),
                SecurityVersionType = SecurityVersionType.Swagger2
            };
        }

        private ICollection<RestEaseSecurityDefinition> Map(IEnumerable<OpenApiSecurityScheme> openApiSecuritySchemes)
        {
            var definitions = new List<RestEaseSecurityDefinition>();
            foreach (var openApiSecurityScheme in openApiSecuritySchemes)
            {
                var restEaseSecurityDefinition = new RestEaseSecurityDefinition
                {
                    Name = openApiSecurityScheme.Name,
                    IdentifierName = openApiSecurityScheme.Name.ToValidIdentifier(CasingType.Pascal)
                };

                switch (openApiSecurityScheme.In)
                {
                    case ParameterLocation.Header:
                        restEaseSecurityDefinition.Type = SecurityDefinitionType.Header;
                        break;

                    case ParameterLocation.Query:
                        restEaseSecurityDefinition.Type = SecurityDefinitionType.Query;
                        break;
                }

                definitions.Add(restEaseSecurityDefinition);
            }

            return definitions;
        }
    }
}