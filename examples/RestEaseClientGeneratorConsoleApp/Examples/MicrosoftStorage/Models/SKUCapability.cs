using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
    /// </summary>
    public class SKUCapability
    {
        /// <summary>
        /// The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A string value to indicate states of given capability. Possibly 'true' or 'false'.
        /// </summary>
        public string Value { get; set; }
    }
}