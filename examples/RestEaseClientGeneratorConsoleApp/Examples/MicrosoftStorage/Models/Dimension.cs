using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Dimension of blobs, possibly be blob type or access tier.
    /// </summary>
    public class Dimension
    {
        /// <summary>
        /// Display name of dimension.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display name of dimension.
        /// </summary>
        public string DisplayName { get; set; }
    }
}