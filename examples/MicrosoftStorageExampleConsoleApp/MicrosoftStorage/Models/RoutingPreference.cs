using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class RoutingPreference
    {
        public string RoutingChoice { get; set; }

        public bool PublishMicrosoftEndpoints { get; set; }

        public bool PublishInternetEndpoints { get; set; }
    }
}