using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The restriction because of which SKU cannot be used.
    /// </summary>
    public class Restriction
    {
        /// <summary>
        /// The type of restrictions. As of now only possible value for this is location.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The value of restrictions. If the restriction type is set to location. This would be different locations where the SKU is restricted.
        /// </summary>
        public string[] Values { get; set; }

        /// <summary>
        /// The reason for the restriction. As of now this can be "QuotaId" or "NotAvailableForSubscription". Quota Id is set when the SKU has requiredQuotas parameter as the subscription does not belong to that quota. The "NotAvailableForSubscription" is related to capacity at DC.
        /// </summary>
        public string ReasonCode { get; set; }
    }
}