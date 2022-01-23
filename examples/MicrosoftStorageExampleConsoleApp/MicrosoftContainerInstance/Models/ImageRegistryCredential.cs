using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// Image registry credential.
    /// </summary>
    public class ImageRegistryCredential
    {
        /// <summary>
        /// The Docker image registry server without a protocol such as "http" and "https".
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// The username for the private registry.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password for the private registry.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The identity for the private registry.
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// The identity URL for the private registry.
        /// </summary>
        public string IdentityUrl { get; set; }
    }
}