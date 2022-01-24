using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
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
        /// The parameters that can be provided when updating the storage account properties.
        /// </summary>
        public Tags Tags { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public Identity Identity { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public StorageAccountPropertiesUpdateParameters Properties { get; set; }

        /// <summary>
        /// Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.
        /// </summary>
        public string Kind { get; set; }
    }
}