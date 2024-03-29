using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The response containing cached images.
    /// </summary>
    public class CachedImagesListResult
    {
        /// <summary>
        /// The list of cached images.
        /// </summary>
        public CachedImages[] Value { get; set; }

        /// <summary>
        /// The URI to fetch the next page of cached images.
        /// </summary>
        public string NextLink { get; set; }
    }
}