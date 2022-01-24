using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// An error response from the Container Instance service.
    /// </summary>
    public class CloudError
    {
        /// <summary>
        /// not-used
        /// </summary>
        public CloudErrorBody Error { get; set; }
    }
}