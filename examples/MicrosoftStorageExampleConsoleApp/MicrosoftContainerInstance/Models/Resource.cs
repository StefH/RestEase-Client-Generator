using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The Resource model definition.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// The resource id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The resource name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The resource type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The resource location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The Resource model definition.
        /// </summary>
        public Tags Tags { get; set; }

        /// <summary>
        /// The zones for the container group.
        /// </summary>
        public string[] Zones { get; set; }
    }
}