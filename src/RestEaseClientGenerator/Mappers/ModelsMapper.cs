using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi;

namespace RestEaseClientGenerator.Mappers
{
    internal class ModelsMapper : BaseMapper
    {
        private readonly OpenApiSpecVersion _openApiSpecVersion;

        public ModelsMapper(GeneratorSettings settings, OpenApiSpecVersion openApiSpecVersion) : base(settings)
        {
            _openApiSpecVersion = openApiSpecVersion;
        }

        public IEnumerable<RestEaseModel> Map(IDictionary<string, OpenApiSchema> schemas)
        {
            return schemas.Where(s => s.Value.GetSchemaType() == SchemaType.Object).Select(x => new RestEaseModel
            {
                Namespace = Settings.Namespace,
                ClassName = MakeValidModelName(x.Key),
                Properties = MapSchema(x.Value, x.Key, x.Value.Nullable, true, _openApiSpecVersion) as ICollection<string>
            });
        }
    }
}