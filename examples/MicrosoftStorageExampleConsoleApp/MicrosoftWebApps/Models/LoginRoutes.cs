using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The routes that specify the endpoints used for login and logout requests.
    /// </summary>
    public class LoginRoutes
    {
        /// <summary>
        /// The endpoint at which a logout request should be made.
        /// </summary>
        public string LogoutEndpoint { get; set; }
    }
}