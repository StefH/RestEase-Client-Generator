using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The SKU of the storage account.
    /// </summary>
    public class Sku
    {
        /// <summary>
        /// The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.
        /// </summary>
        public int Name { get; set; }

        /// <summary>
        /// The SKU tier. This is based on the SKU name.
        /// </summary>
        public int Tier { get; set; }
    }
}