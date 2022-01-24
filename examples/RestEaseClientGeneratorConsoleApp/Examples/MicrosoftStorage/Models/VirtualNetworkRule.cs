using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Virtual Network rule.
    /// </summary>
    public class VirtualNetworkRule
    {
        /// <summary>
        /// Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The action of virtual network rule.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Gets the state of virtual network rule.
        /// </summary>
        public string State { get; set; }
    }
}