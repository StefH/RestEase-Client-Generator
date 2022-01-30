using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// An error response from the Container Instance service.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class CloudError
    {
        /// <summary>
        /// An error response from the Container Instance service.
        /// </summary>
        public CloudErrorBody Error { get; set; }
    }
}