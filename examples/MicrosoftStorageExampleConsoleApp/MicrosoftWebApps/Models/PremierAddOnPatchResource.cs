using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// ARM resource for a PremierAddOn.
    /// </summary>
    public class PremierAddOnPatchResource : ProxyOnlyResource
    {
        /// <summary>
        /// PremierAddOnPatchResource resource specific properties
        /// </summary>
        public PremierAddOnPatchResourceProperties Properties { get; set; }

    }
}