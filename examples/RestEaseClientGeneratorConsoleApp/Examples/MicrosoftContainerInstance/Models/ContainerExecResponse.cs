using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The information for the container exec command.
    /// </summary>
    public class ContainerExecResponse
    {
        /// <summary>
        /// The uri for the exec websocket.
        /// </summary>
        public string WebSocketUri { get; set; }

        /// <summary>
        /// The password to start the exec command.
        /// </summary>
        public string Password { get; set; }
    }
}