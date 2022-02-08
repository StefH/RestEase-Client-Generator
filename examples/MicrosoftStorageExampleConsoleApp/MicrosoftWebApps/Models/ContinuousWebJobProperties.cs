using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// ContinuousWebJob resource specific properties
    /// </summary>
    public class ContinuousWebJobProperties
    {
        /// <summary>
        /// Job status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Detailed status.
        /// </summary>
        public string DetailedStatus { get; set; }

        /// <summary>
        /// Log URL.
        /// </summary>
        public string LogUrl { get; set; }

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
        public Dictionary<string, ContinuousWebJobPropertiesSettings> ContinuousWebJobPropertiesSettings { get; set; }
    }
}