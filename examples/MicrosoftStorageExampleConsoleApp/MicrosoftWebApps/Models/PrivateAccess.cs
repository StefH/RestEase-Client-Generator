using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Description of the parameters of Private Access for a Web Site.
    /// </summary>
    public class PrivateAccess : ProxyOnlyResource 
    {
        /// <summary>
        /// PrivateAccess resource specific properties
        /// </summary>
        public PrivateAccessProperties Properties { get; set; }

    }
}