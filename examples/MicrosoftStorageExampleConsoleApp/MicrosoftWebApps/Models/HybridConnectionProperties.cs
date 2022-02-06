using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// HybridConnection resource specific properties
    /// </summary>
    public class HybridConnectionProperties
    {
        /// <summary>
        /// The name of the Service Bus namespace.
        /// </summary>
        public string ServiceBusNamespace { get; set; }

        /// <summary>
        /// The name of the Service Bus relay.
        /// </summary>
        public string RelayName { get; set; }

        /// <summary>
        /// The ARM URI to the Service Bus relay.
        /// </summary>
        public string RelayArmUri { get; set; }

        /// <summary>
        /// The hostname of the endpoint.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// The port of the endpoint.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The name of the Service Bus key which has Send permissions. This is used to authenticate to Service Bus.
        /// </summary>
        public string SendKeyName { get; set; }

        /// <summary>
        /// The value of the Service Bus key. This is used to authenticate to Service Bus. In ARM this key will not be returnednormally, use the POST /listKeys API instead.
        /// </summary>
        public string SendKeyValue { get; set; }

        /// <summary>
        /// The suffix for the service bus endpoint. By default this is .servicebus.windows.net
        /// </summary>
        public string ServiceBusSuffix { get; set; }
    }
}