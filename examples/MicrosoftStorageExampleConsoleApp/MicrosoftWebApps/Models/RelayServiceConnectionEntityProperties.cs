using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// RelayServiceConnectionEntity resource specific properties
    /// </summary>
    public class RelayServiceConnectionEntityProperties
    {
        public string EntityName { get; set; }

        public string EntityConnectionString { get; set; }

        public string ResourceType { get; set; }

        public string ResourceConnectionString { get; set; }

        public string Hostname { get; set; }

        public int Port { get; set; }

        public string BiztalkUri { get; set; }
    }
}