using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// String dictionary resource.
    /// </summary>
    public class ConnectionStringDictionary : ProxyOnlyResource 
    {
        /// <summary>
        /// Connection strings.
        /// </summary>
        public Dictionary<string, ConnStringValueTypePair> Properties { get; set; }

    }
}