using System.Collections.Generic;

namespace RestEaseClientGenerator.Models.Internal
{
    internal class RequestDetails
    {
        public string DetectedContentType { get; set; }

        public ICollection<string> ContentTypes { get; set; }

        public bool IsExtension { get; set; }
    }
}