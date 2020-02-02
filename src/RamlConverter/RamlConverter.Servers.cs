using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using RamlToOpenApiConverter.Extensions;

namespace RamlToOpenApiConverter
{
    public partial class RamlConverter
    {
        private IList<OpenApiServer> MapServers(IDictionary<object, object> items)
        {
            return new List<OpenApiServer>
            {
                new OpenApiServer
                {
                    Url = items.Get("baseUri")
                }
            };
        }
    }
}