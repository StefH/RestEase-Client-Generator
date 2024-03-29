using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Routing preference defines the type of network, either microsoft or internet routing to be used to deliver the user data, the default option is microsoft routing
    /// </summary>
    public class RoutingPreference
    {
        /// <summary>
        /// Routing Choice defines the kind of network routing opted by the user.
        /// </summary>
        public string RoutingChoice { get; set; }

        /// <summary>
        /// A boolean flag which indicates whether microsoft routing storage endpoints are to be published
        /// </summary>
        public bool PublishMicrosoftEndpoints { get; set; }

        /// <summary>
        /// A boolean flag which indicates whether internet routing storage endpoints are to be published
        /// </summary>
        public bool PublishInternetEndpoints { get; set; }
    }
}