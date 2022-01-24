using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The storage account.
    /// </summary>
    public class StorageAccount : TrackedResource
    {
        /// <summary>
        /// not-used
        /// </summary>
        public Sku Sku { get; set; }

        /// <summary>
        /// Gets the Kind.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public Identity Identity { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ExtendedLocation ExtendedLocation { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public StorageAccountProperties Properties { get; set; }

    }
}