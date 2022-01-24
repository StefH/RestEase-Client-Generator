using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The service properties for soft delete.
    /// </summary>
    public class DeleteRetentionPolicy
    {
        /// <summary>
        /// Indicates whether DeleteRetentionPolicy is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Indicates the number of days that the deleted item should be retained. The minimum specified value can be 1 and the maximum value can be 365.
        /// </summary>
        public int Days { get; set; }
    }
}