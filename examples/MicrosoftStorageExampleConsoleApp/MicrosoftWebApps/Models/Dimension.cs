using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Dimension of a resource metric. For e.g. instance specific HTTP requests for a web app, where instance name is dimension of the metric HTTP request
    /// </summary>
    public class Dimension
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string InternalName { get; set; }

        public bool ToBeExportedForShoebox { get; set; }
    }
}