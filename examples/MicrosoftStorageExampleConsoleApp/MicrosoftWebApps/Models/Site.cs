using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// A web app, a mobile app backend, or an API app.
    /// </summary>
    public class Site : Resource
    {
        /// <summary>
        /// Site resource specific properties
        /// </summary>
        public SiteProperties Properties { get; set; }

        /// <summary>
        /// Managed service identity.
        /// </summary>
        public ManagedServiceIdentity Identity { get; set; }

        /// <summary>
        /// Extended Location.
        /// </summary>
        public ExtendedLocation ExtendedLocation { get; set; }

    }
}