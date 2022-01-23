using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// An object that wraps the Lifecycle rule. Each rule is uniquely defined by name.
    /// </summary>
    public class ManagementPolicyRule
    {
        /// <summary>
        /// Rule is enabled if set to true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The valid value is Lifecycle
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ManagementPolicyDefinition Definition { get; set; }
    }
}