using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// A collection of information about the state of the connection between service consumer and provider.
    /// </summary>
    public class PrivateLinkServiceConnectionState
    {
        /// <summary>
        /// The private endpoint connection status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The reason for approval/rejection of the connection.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A message indicating if changes on the service provider require any updates on the consumer.
        /// </summary>
        public string ActionsRequired { get; set; }
    }
}