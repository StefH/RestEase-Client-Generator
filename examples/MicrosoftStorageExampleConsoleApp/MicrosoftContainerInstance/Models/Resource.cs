using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The Resource model definition.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
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
        /// The resource tags.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// The zones for the container group.
        /// </summary>
        public string[] Zones { get; set; }
    }
}