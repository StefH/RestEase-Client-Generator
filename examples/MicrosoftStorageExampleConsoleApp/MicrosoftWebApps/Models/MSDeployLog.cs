using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// MSDeploy log
    /// </summary>
    public class MSDeployLog : ProxyOnlyResource 
    {
        /// <summary>
        /// MSDeployLog resource specific properties
        /// </summary>
        public MSDeployLogProperties Properties { get; set; }

    }
}