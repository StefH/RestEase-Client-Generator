using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the nonce used in the login flow.
    /// </summary>
    public class Nonce
    {
        /// <summary>
        /// false if the nonce should not be validated while completing the login flow; otherwise, true.
        /// </summary>
        public bool ValidateNonce { get; set; }

        /// <summary>
        /// The time after the request is made when the nonce should expire.
        /// </summary>
        public string NonceExpirationInterval { get; set; }
    }
}