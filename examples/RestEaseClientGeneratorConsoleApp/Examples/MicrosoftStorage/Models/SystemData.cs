using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Metadata pertaining to creation and last modification of the resource.
    /// </summary>
    public class SystemData
    {
        /// <summary>
        /// The identity that created the resource.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// The type of identity that created the resource.
        /// </summary>
        public string CreatedByType { get; set; }

        /// <summary>
        /// The timestamp of resource creation (UTC).
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The identity that last modified the resource.
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// The type of identity that last modified the resource.
        /// </summary>
        public string LastModifiedByType { get; set; }

        /// <summary>
        /// The timestamp of resource last modification (UTC)
        /// </summary>
        public DateTime LastModifiedAt { get; set; }
    }
}