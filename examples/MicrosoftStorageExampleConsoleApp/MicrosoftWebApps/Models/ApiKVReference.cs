using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Description of site key vault references.
    /// </summary>
    public class ApiKVReference : ProxyOnlyResource
    {
        /// <summary>
        /// ApiKVReference resource specific properties
        /// </summary>
        public ApiKVReferenceProperties Properties { get; set; }

    }
}