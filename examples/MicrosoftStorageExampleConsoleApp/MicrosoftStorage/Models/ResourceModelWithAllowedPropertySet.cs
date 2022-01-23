using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class ResourceModelWithAllowedPropertySet
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        public string ManagedBy { get; set; }

        public string Kind { get; set; }

        public string Etag { get; set; }

        public Tags Tags { get; set; }

        public Identity Identity { get; set; }

        public Sku Sku { get; set; }

        public Plan Plan { get; set; }
    }
}