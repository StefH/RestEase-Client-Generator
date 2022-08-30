using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Storage SKU and its properties
    /// </summary>
    public class SkuInformation
    {
        /// <summary>
        /// The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The SKU tier. This is based on the SKU name.
        /// </summary>
        public string Tier { get; set; }

        /// <summary>
        /// The type of the resource, usually it is 'storageAccounts'.
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// Indicates the type of storage account.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.).
        /// </summary>
        public string[] Locations { get; set; }

        /// <summary>
        /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
        /// </summary>
        public SKUCapability[] Capabilities { get; set; }

        /// <summary>
        /// The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
        /// </summary>
        public Restriction[] Restrictions { get; set; }
    }
}