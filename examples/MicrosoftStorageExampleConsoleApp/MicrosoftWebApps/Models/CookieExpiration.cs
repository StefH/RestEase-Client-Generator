using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the session cookie's expiration.
    /// </summary>
    public class CookieExpiration
    {
        /// <summary>
        /// The convention used when determining the session cookie's expiration.
        /// </summary>
        public string Convention { get; set; }

        /// <summary>
        /// The time after the request is made when the session cookie should expire.
        /// </summary>
        public string TimeToExpiration { get; set; }
    }
}