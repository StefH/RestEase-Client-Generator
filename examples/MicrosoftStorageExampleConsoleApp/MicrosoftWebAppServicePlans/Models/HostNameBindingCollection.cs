using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Collection of hostname bindings.
    /// </summary>
    public class HostNameBindingCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public HostNameBinding[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}