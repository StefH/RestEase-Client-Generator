using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// MSDeploy ARM PUT information
    /// </summary>
    public class MSDeploy : ProxyOnlyResource
    {
        /// <summary>
        /// MSDeploy ARM PUT core information
        /// </summary>
        public MSDeployCore Properties { get; set; }

    }
}