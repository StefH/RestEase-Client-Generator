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
        /// not-used
        /// </summary>
        public ExtendedLocation ExtendedLocation { get; set; }

        /// <summary>
        /// The parameters used when creating a storage account.
        /// </summary>
        public StorageAccountCreateParametersTags Tags { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public Identity Identity { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public StorageAccountPropertiesCreateParameters Properties { get; set; }
    }
}