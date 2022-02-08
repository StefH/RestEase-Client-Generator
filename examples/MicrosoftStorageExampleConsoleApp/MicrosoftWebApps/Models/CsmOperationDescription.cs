using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Description of an operation available for Microsoft.Web resource provider.
    /// </summary>
    public class CsmOperationDescription
    {
        public string Name { get; set; }

        public bool IsDataAction { get; set; }

        /// <summary>
        /// Meta data about operation used for display in portal.
        /// </summary>
        public CsmOperationDisplay Display { get; set; }

        public string Origin { get; set; }

        /// <summary>
        /// Properties available for a Microsoft.Web resource provider operation.
        /// </summary>
        public CsmOperationDescriptionProperties Properties { get; set; }
    }
}