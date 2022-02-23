using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// A deleted app.
    /// </summary>
    public class DeletedSite : ProxyOnlyResource 
    {
        /// <summary>
        /// DeletedSite resource specific properties
        /// </summary>
        public DeletedSiteProperties Properties { get; set; }

    }
}