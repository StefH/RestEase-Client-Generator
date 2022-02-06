using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Localizable string object containing the name and a localized value.
    /// </summary>
    public class LocalizableString
    {
        /// <summary>
        /// Non-localized name.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Localized name.
        /// </summary>
        public string LocalizedValue { get; set; }
    }
}