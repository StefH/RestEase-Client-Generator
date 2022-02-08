using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of CSM usage quotas.
    /// </summary>
    public class CsmUsageQuotaCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public CsmUsageQuota[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}