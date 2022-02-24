using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Private Endpoint Connection Approval ARM resource.
    /// </summary>
    public class PrivateLinkConnectionApprovalRequestResource : ProxyOnlyResource 
    {
        /// <summary>
        /// A request to approve or reject a private endpoint connection
        /// </summary>
        public PrivateLinkConnectionApprovalRequest Properties { get; set; }

    }
}