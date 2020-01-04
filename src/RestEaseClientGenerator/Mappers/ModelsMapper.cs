using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using System.Collections.Generic;
using System.Linq;

namespace RestEaseClientGenerator.Mappers
{
    internal class ModelsMapper : BaseMapper
    {
        public ModelsMapper(GeneratorSettings settings) : base(settings)
        {
        }

        public IEnumerable<RestEaseModel> Map(IDictionary<string, OpenApiSchema> schemas)
        {
            return schemas.Where(s => s.Value.GetSchemaType() == SchemaType.Object).Select(x => new RestEaseModel
            {
                Namespace = Settings.Namespace,
                ClassName = MakeValidModelName(x.Key),
                Properties = MapSchema(x.Value, x.Key, x.Value.Nullable) as ICollection<string>
            });
        }
    }
}