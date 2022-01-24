using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The Get Storage Account ManagementPolicies operation response.
    /// </summary>
    public class ManagementPolicy : Resource
    {
        /// <summary>
        /// not-used
        /// </summary>
        public ManagementPolicyProperties Properties { get; set; }

    }
}