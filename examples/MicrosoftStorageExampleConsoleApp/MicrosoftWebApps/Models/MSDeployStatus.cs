using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// MSDeploy ARM response
    /// </summary>
    public class MSDeployStatus : ProxyOnlyResource
    {
        /// <summary>
        /// MSDeployStatus resource specific properties
        /// </summary>
        public MSDeployStatusProperties Properties { get; set; }

    }
}