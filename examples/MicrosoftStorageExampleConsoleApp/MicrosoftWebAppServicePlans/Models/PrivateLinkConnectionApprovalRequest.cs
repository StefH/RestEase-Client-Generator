using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// A request to approve or reject a private endpoint connection
    /// </summary>
    public class PrivateLinkConnectionApprovalRequest
    {
        /// <summary>
        /// The state of a private link connection
        /// </summary>
        public PrivateLinkConnectionState PrivateLinkServiceConnectionState { get; set; }
    }
}