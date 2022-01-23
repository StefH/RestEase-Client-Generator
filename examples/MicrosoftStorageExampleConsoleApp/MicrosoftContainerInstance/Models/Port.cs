using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The port exposed on the container group.
    /// </summary>
    public class Port
    {
        /// <summary>
        /// The protocol associated with the port.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// The port number.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Port")]
        public int Port_ { get; set; }
    }
}