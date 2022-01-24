using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// KeyPolicy assigned to the storage account.
    /// </summary>
    public class KeyPolicy
    {
        /// <summary>
        /// The key expiration period in days.
        /// </summary>
        public int KeyExpirationPeriodInDays { get; set; }
    }
}