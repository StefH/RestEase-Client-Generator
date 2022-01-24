using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// SasPolicy assigned to the storage account.
    /// </summary>
    public class SasPolicy
    {
        /// <summary>
        /// The SAS expiration period, DD.HH:MM:SS.
        /// </summary>
        public string SasExpirationPeriod { get; set; }

        /// <summary>
        /// The SAS expiration action. Can only be Log.
        /// </summary>
        public string ExpirationAction { get; set; }
    }
}