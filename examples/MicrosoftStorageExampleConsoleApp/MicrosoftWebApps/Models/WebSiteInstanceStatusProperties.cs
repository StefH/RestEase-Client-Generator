using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// WebSiteInstanceStatus resource specific properties
    /// </summary>
    public class WebSiteInstanceStatusProperties
    {
        public string State { get; set; }

        /// <summary>
        /// Link to the GetStatusApi in Kudu
        /// </summary>
        public string StatusUrl { get; set; }

        /// <summary>
        /// Link to the Diagnose and Solve Portal
        /// </summary>
        public string DetectorUrl { get; set; }

        /// <summary>
        /// Link to the console to web app instance
        /// </summary>
        public string ConsoleUrl { get; set; }

        /// <summary>
        /// Link to the console to web app instance
        /// </summary>
        public string HealthCheckUrl { get; set; }

        public Dictionary<string, ContainerInfo> Containers { get; set; }
    }
}