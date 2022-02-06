using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// VnetRoute resource specific properties
    /// </summary>
    public class VnetRouteProperties
    {
        /// <summary>
        /// The starting address for this route. This may also include a CIDR notation, in which case the end address must not be specified.
        /// </summary>
        public string StartAddress { get; set; }

        /// <summary>
        /// The ending address for this route. If the start address is specified in CIDR notation, this must be omitted.
        /// </summary>
        public string EndAddress { get; set; }

        /// <summary>
        /// The type of route this is:DEFAULT - By default, every app has routes to the local address ranges specified by RFC1918INHERITED - Routes inherited from the real Virtual Network routesSTATIC - Static route set on the app onlyThese values will be used for syncing an app's routes with those from a Virtual Network.
        /// </summary>
        public string RouteType { get; set; }
    }
}