using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
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
    }
}