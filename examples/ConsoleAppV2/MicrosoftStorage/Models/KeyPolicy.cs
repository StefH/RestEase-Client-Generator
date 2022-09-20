using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// KeyPolicy assigned to the storage account.
    /// </summary>
    public class KeyPolicy
    {
        /// <summary>
        /// The key expiration period in days.
        /// </summary>
        public System.Int32 KeyExpirationPeriodInDays { get; set; }
    }
}