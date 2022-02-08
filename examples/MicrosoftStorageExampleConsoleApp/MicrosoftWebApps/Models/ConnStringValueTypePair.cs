using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Database connection string value to type pair.
    /// </summary>
    public class ConnStringValueTypePair
    {
        /// <summary>
        /// Value of pair.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Type of database.
        /// </summary>
        public string Type { get; set; }
    }
}