using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The current status of an async operation.
    /// </summary>
    public class OperationStatusResult
    {
        /// <summary>
        /// Fully qualified ID for the async operation.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the async operation.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Operation status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Percent of the operation that is complete.
        /// </summary>
        public double PercentComplete { get; set; }

        /// <summary>
        /// The start time of the operation.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The end time of the operation.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// The operations list.
        /// </summary>
        public OperationStatusResult[] Operations { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ErrorDetail Error { get; set; }
    }
}