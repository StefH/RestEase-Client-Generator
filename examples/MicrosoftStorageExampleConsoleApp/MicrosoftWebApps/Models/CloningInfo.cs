using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Information needed for cloning operation.
    /// </summary>
    public class CloningInfo
    {
        /// <summary>
        /// Correlation ID of cloning operation. This ID ties multiple cloning operationstogether to use the same snapshot.
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// true to overwrite destination app; otherwise, false.
        /// </summary>
        public bool Overwrite { get; set; }

        /// <summary>
        /// true to clone custom hostnames from source app; otherwise, false.
        /// </summary>
        public bool CloneCustomHostNames { get; set; }

        /// <summary>
        /// true to clone source control from source app; otherwise, false.
        /// </summary>
        public bool CloneSourceControl { get; set; }

        /// <summary>
        /// ARM resource ID of the source app. App resource ID is of the form /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
        /// </summary>
        public string SourceWebAppId { get; set; }

        /// <summary>
        /// Location of source app ex: West US or North Europe
        /// </summary>
        public string SourceWebAppLocation { get; set; }

        /// <summary>
        /// App Service Environment.
        /// </summary>
        public string HostingEnvironment { get; set; }

        /// <summary>
        /// Application setting overrides for cloned app. If specified, these settings override the settings cloned from source app. Otherwise, application settings from source app are retained.
        /// </summary>
        public Dictionary<string, string> AppSettingsOverrides { get; set; }

        /// <summary>
        /// true to configure load balancing for source and destination app.
        /// </summary>
        public bool ConfigureLoadBalancing { get; set; }

        /// <summary>
        /// ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
        /// </summary>
        public string TrafficManagerProfileId { get; set; }

        /// <summary>
        /// Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
        /// </summary>
        public string TrafficManagerProfileName { get; set; }
    }
}