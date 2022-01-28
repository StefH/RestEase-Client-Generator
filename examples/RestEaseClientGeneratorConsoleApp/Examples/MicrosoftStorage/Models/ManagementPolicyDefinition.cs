using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// An object that defines the Lifecycle rule. Each definition is made up with a filters set and an actions set.
    /// </summary>
    public class ManagementPolicyDefinition
    {
        /// <summary>
        /// Actions are applied to the filtered blobs when the execution condition is met.
        /// </summary>
        public ManagementPolicyAction Actions { get; set; }

        /// <summary>
        /// Filters limit rule actions to a subset of blobs within the storage account. If multiple filters are defined, a logical AND is performed on all filters. 
        /// </summary>
        public ManagementPolicyFilter Filters { get; set; }
    }
}