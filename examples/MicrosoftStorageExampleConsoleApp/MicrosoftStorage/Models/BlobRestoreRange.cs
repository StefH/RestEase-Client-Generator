using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Blob range
    /// </summary>
    public class BlobRestoreRange
    {
        /// <summary>
        /// Blob start range. This is inclusive. Empty means account start.
        /// </summary>
        public string StartRange { get; set; }

        /// <summary>
        /// Blob end range. This is exclusive. Empty means account end.
        /// </summary>
        public string EndRange { get; set; }
    }
}