using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The resource model definition for an Azure Resource Manager resource with an etag.
    /// </summary>
    public class AzureEntityResource : Resource 
    {
        /// <summary>
        /// Resource Etag.
        /// </summary>
        public string Etag { get; set; }

    }
}