using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// PremierAddOn resource specific properties
    /// </summary>
    public class PremierAddOnProperties
    {
        /// <summary>
        /// Premier add on SKU.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Premier add on Product.
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Premier add on Vendor.
        /// </summary>
        public string Vendor { get; set; }

        /// <summary>
        /// Premier add on Marketplace publisher.
        /// </summary>
        public string MarketplacePublisher { get; set; }

        /// <summary>
        /// Premier add on Marketplace offer.
        /// </summary>
        public string MarketplaceOffer { get; set; }
    }
}