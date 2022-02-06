using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// WebJob resource specific properties
    /// </summary>
    public class WebJobProperties
    {
        /// <summary>
        /// Run command.
        /// </summary>
        public string RunCommand { get; set; }

        /// <summary>
        /// Job URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Extra Info URL.
        /// </summary>
        public string ExtraInfoUrl { get; set; }

        /// <summary>
        /// Job type.
        /// </summary>
        public string WebJobType { get; set; }

        /// <summary>
        /// Error information.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Using SDK?
        /// </summary>
        public bool UsingSdk { get; set; }

        /// <summary>
        /// Job settings.
        /// </summary>
        public Dictionary<string, WebJobPropertiesSettings> WebJobPropertiesSettings { get; set; }
    }
}