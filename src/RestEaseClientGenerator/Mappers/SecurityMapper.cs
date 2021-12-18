using System;
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
        private static readonly string[] SecuritySchemaTypes = { "api_key" };

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
                return MapOpenApiVersion3(new Dictionary<string, OpenApiSecurityScheme>(openApiDocument.Components.SecuritySchemes, StringComparer.OrdinalIgnoreCase));
            }

            return null;
        }

        private RestEaseSecurity MapOpenApiVersion3(IDictionary<string, OpenApiSecurityScheme> schemas)
        {
            foreach (var securitySchemaType in SecuritySchemaTypes)
            {
                if (schemas.TryGetValue(securitySchemaType, out var openApiSecurityScheme))
                {
                    return new RestEaseSecurity
                    {
                        Definitions = Map(new[] { openApiSecurityScheme }),
                        SecurityVersionType = SecurityVersionType.OpenApi3
                    };
                }
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
                string name = openApiSecurityScheme.Name ?? openApiSecurityScheme.Description ?? "RestEaseClientGeneratorSecurityName";
                var restEaseSecurityDefinition = new RestEaseSecurityDefinition
                {
                    Name = name,
                    IdentifierName = name.ToValidIdentifier(CasingType.Pascal)
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