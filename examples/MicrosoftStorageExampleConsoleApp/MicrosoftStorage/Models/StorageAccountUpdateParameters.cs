using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The parameters that can be provided when updating the storage account properties.
    /// </summary>
    public class StorageAccountUpdateParameters
    {
        /// <summary>
        /// not-used
        /// </summary>
        public Sku Sku { get; set; }

        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters.
        /// </summary>
        public StorageAccountUpdateParametersTags Tags { get; set; }

        /// <summary>
        /// Identity for the resource.
        /// </summary>
        public Identity Identity { get; set; }

        /// <summary>
        /// The parameters used when updating a storage account.
        /// </summary>
        public StorageAccountPropertiesUpdateParameters Properties { get; set; }

        /// <summary>
        /// Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.
        /// </summary>
        public string Kind { get; set; }
    }
}