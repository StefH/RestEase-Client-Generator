using System.Collections.Generic;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Models.Internal
{
    internal class RestEaseSecurity
    {
        public ICollection<RestEaseSecurityDefinition> Definitions { get; set; }

        public SecurityVersionType SecurityVersionType { get; set; }
    }
}