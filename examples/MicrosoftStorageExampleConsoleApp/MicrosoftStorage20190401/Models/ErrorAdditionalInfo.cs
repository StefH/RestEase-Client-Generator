using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The resource management error additional info.
    /// </summary>
    public class ErrorAdditionalInfo
    {
        /// <summary>
        /// The additional info type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The resource management error additional info.
        /// </summary>
        public Info Info { get; set; }
    }
}