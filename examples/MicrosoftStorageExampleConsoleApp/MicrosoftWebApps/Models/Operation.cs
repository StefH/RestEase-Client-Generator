using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// An operation on a resource.
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Operation ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Operation name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The current status of the operation.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Any errors associate with the operation.
        /// </summary>
        public ErrorEntity[] Errors { get; set; }

        /// <summary>
        /// Time when operation has started.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Time when operation has been updated.
        /// </summary>
        public DateTime ModifiedTime { get; set; }

        /// <summary>
        /// Time when operation will expire.
        /// </summary>
        public DateTime ExpirationTime { get; set; }

        /// <summary>
        /// Applicable only for stamp operation ids.
        /// </summary>
        public string GeoMasterOperationId { get; set; }
    }
}