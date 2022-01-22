using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class Port
    {
        public string Protocol { get; set; }

        [Newtonsoft.Json.JsonProperty("Port")]
        public int Port_ { get; set; }
    }
}