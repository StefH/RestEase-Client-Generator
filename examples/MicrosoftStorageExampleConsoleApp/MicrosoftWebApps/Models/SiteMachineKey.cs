using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// MachineKey of an app.
    /// </summary>
    public class SiteMachineKey
    {
        /// <summary>
        /// MachineKey validation.
        /// </summary>
        public string Validation { get; set; }

        /// <summary>
        /// Validation key.
        /// </summary>
        public string ValidationKey { get; set; }

        /// <summary>
        /// Algorithm used for decryption.
        /// </summary>
        public string Decryption { get; set; }

        /// <summary>
        /// Decryption key.
        /// </summary>
        public string DecryptionKey { get; set; }
    }
}