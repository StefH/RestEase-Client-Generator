using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The information for the output stream from container attach.
    /// </summary>
    public class ContainerAttachResponse
    {
        /// <summary>
        /// The uri for the output stream from the attach.
        /// </summary>
        public string WebSocketUri { get; set; }

        /// <summary>
        /// The password to the output stream from the attach. Send as an Authorization header value when connecting to the websocketUri.
        /// </summary>
        public string Password { get; set; }
    }
}