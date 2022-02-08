using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// ARM resource for a site.
    /// </summary>
    public class SitePatchResource : ProxyOnlyResource
    {
        /// <summary>
        /// SitePatchResource resource specific properties
        /// </summary>
        public SitePatchResourceProperties Properties { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ManagedServiceIdentity Identity { get; set; }

    }
}