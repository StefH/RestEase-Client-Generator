using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of each of the identity providers used to configure App Service Authentication/Authorization.
    /// </summary>
    public class IdentityProviders
    {
        /// <summary>
        /// The configuration settings of the Azure Active directory provider.
        /// </summary>
        public AzureActiveDirectory AzureActiveDirectory { get; set; }

        /// <summary>
        /// The configuration settings of the Facebook provider.
        /// </summary>
        public Facebook Facebook { get; set; }

        /// <summary>
        /// The configuration settings of the GitHub provider.
        /// </summary>
        public GitHub GitHub { get; set; }

        /// <summary>
        /// The configuration settings of the Google provider.
        /// </summary>
        public Google Google { get; set; }

        /// <summary>
        /// The configuration settings of the legacy Microsoft Account provider.
        /// </summary>
        public LegacyMicrosoftAccount LegacyMicrosoftAccount { get; set; }

        /// <summary>
        /// The configuration settings of the Twitter provider.
        /// </summary>
        public Twitter Twitter { get; set; }

        /// <summary>
        /// The configuration settings of the Apple provider.
        /// </summary>
        public Apple Apple { get; set; }

        /// <summary>
        /// The configuration settings of the Azure Static Web Apps provider.
        /// </summary>
        public AzureStaticWebApps AzureStaticWebApps { get; set; }

        /// <summary>
        /// The map of the name of the alias of each custom Open ID Connect provider to theconfiguration settings of the custom Open ID Connect provider.
        /// </summary>
        public Dictionary<string, CustomOpenIdConnectProvider> CustomOpenIdConnectProviders { get; set; }
    }
}