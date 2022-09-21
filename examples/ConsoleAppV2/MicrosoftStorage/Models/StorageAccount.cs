using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The storage account.
    /// </summary>
    public class StorageAccount : TrackedResource
    {
        /// <summary>
        /// The SKU of the storage account.
        /// </summary>
        public Sku Sku { get; set; }

        /// <summary>
        /// Gets the Kind.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Identity for the resource.
        /// </summary>
        public Identity Identity { get; set; }

        /// <summary>
        /// The complex type of the extended location.
        /// </summary>
        public ExtendedLocation ExtendedLocation { get; set; }

        /// <summary>
        /// Properties of the storage account.
        /// </summary>
        public StorageAccountProperties Properties { get; set; }
    }
}