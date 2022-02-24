using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Continuous Web Job Information.
    /// </summary>
    public class ContinuousWebJob : ProxyOnlyResource 
    {
        /// <summary>
        /// ContinuousWebJob resource specific properties
        /// </summary>
        public ContinuousWebJobProperties Properties { get; set; }

    }
}