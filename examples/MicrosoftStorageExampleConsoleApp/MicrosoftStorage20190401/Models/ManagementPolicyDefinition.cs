using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// An object that defines the Lifecycle rule. Each definition is made up with a filters set and an actions set.
    /// </summary>
    public class ManagementPolicyDefinition
    {
        /// <summary>
        /// not-used
        /// </summary>
        public ManagementPolicyAction Actions { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ManagementPolicyFilter Filters { get; set; }
    }
}