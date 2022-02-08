using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Publishing Credentials Policies entity collection ARM resource.
    /// </summary>
    public class PublishingCredentialsPoliciesCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public CsmPublishingCredentialsPoliciesEntity[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}