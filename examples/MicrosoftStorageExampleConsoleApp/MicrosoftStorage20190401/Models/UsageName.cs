using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The usage names that can be used; currently limited to StorageAccount.
    /// </summary>
    public class UsageName
    {
        /// <summary>
        /// Gets a string describing the resource name.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets a localized string describing the resource name.
        /// </summary>
        public string LocalizedValue { get; set; }
    }
}