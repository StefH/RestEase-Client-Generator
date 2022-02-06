using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Properties available for a Microsoft.Web resource provider operation.
    /// </summary>
    public class CsmOperationDescriptionProperties
    {
        /// <summary>
        /// Resource metrics service provided by Microsoft.Insights resource provider.
        /// </summary>
        public ServiceSpecification ServiceSpecification { get; set; }
    }
}