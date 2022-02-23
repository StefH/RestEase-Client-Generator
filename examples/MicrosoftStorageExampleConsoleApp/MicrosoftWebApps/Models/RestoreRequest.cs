using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Description of a restore request.
    /// </summary>
    public class RestoreRequest : ProxyOnlyResource 
    {
        /// <summary>
        /// RestoreRequest resource specific properties
        /// </summary>
        public RestoreRequestProperties Properties { get; set; }

    }
}