using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// PushSettings resource specific properties
    /// </summary>
    public class PushSettingsProperties
    {
        /// <summary>
        /// Gets or sets a flag indicating whether the Push endpoint is enabled.
        /// </summary>
        public bool IsPushEnabled { get; set; }

        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
        /// </summary>
        public string TagWhitelistJson { get; set; }

        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.Tags can consist of alphanumeric characters and the following:'_', '@', '#', '.', ':', '-'. Validation should be performed at the PushRequestHandler.
        /// </summary>
        public string TagsRequiringAuth { get; set; }

        /// <summary>
        /// Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
        /// </summary>
        public string DynamicTagsJson { get; set; }
    }
}