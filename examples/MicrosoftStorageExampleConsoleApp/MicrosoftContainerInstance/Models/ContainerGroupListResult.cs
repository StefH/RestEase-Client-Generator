using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The container group list response that contains the container group properties.
    /// </summary>
    public class ContainerGroupListResult
    {
        /// <summary>
        /// The list of container groups.
        /// </summary>
        public ContainerGroup[] Value { get; set; }

        /// <summary>
        /// The URI to fetch the next page of container groups.
        /// </summary>
        public string NextLink { get; set; }
    }
}