using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Auth Secrets for Container App Scale Rule
    /// </summary>
    public class ScaleRuleAuth
    {
        /// <summary>
        /// Name of the Container App secret from which to pull the auth params.
        /// </summary>
        public string SecretRef { get; set; }

        /// <summary>
        /// Trigger Parameter that uses the secret
        /// </summary>
        public string TriggerParameter { get; set; }
    }
}