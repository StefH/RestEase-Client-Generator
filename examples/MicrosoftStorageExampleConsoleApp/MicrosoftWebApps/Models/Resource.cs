using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Azure resource. This resource is tracked in Azure Resource Manager
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Resource Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Resource Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Kind of resource.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Resource Location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Resource type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Resource tags.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }
    }
}