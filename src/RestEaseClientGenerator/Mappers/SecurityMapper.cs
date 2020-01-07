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
            if (openApiDocument.SecurityRequirements != null)
            {
                var restEaseSecurity = new RestEaseSecurity
                {
                    Definitions = new List<RestEaseSecurityDefinition>(),
                    SecurityVersionType = SecurityVersionType.Swagger2
                };

                var openApiSecuritySchemes = openApiDocument.SecurityRequirements
                    .Select(sr => sr.Keys.FirstOrDefault())
                    .Where(k => k != null);

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

                    restEaseSecurity.Definitions.Add(restEaseSecurityDefinition);
                }

                return restEaseSecurity;
            }

            return null;
        }
    }
}
