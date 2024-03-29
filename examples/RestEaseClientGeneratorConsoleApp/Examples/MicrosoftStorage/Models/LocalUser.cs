using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The local user associated with the storage accounts.
    /// </summary>
    public class LocalUser : Resource
    {
        /// <summary>
        /// The Storage Account Local User properties.
        /// </summary>
        public LocalUserProperties Properties { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public SystemData SystemData { get; set; }

    }
}