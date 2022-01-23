using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The custom domain assigned to this storage account. This can be set via Update.
    /// </summary>
    public class CustomDomain
    {
        /// <summary>
        /// Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.
        /// </summary>
        public bool UseSubDomainName { get; set; }
    }
}