using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The parameters used when creating a storage account.
    /// </summary>
    public class StorageAccountCreateParameters
    {
        /// <summary>
        /// not-used
        /// </summary>
        public Sku Sku { get; set; }

        /// <summary>
        /// Required. Indicates the type of storage account.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Required. Gets or sets the location of the resource. This will be one of the supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The complex type of the extended location.
        /// </summary>
        public ExtendedLocation ExtendedLocation { get; set; }

        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource. These tags can be used for viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key with a length no greater than 128 characters and a value with a length no greater than 256 characters.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Identity for the resource.
        /// </summary>
        public Identity Identity { get; set; }

        /// <summary>
        /// The parameters used to create the storage account.
        /// </summary>
        public StorageAccountPropertiesCreateParameters Properties { get; set; }
    }
}