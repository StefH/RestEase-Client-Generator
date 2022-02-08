using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Premier add-on.
    /// </summary>
    public class PremierAddOn : Resource
    {
        /// <summary>
        /// PremierAddOn resource specific properties
        /// </summary>
        public PremierAddOnProperties Properties { get; set; }

    }
}