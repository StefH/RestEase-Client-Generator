using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Publishing options for requested profile.
    /// </summary>
    public class CsmPublishingProfileOptions
    {
        /// <summary>
        /// Name of the format. Valid values are: FileZilla3WebDeploy -- defaultFtp
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Include the DisasterRecover endpoint if true
        /// </summary>
        public bool IncludeDisasterRecoveryEndpoints { get; set; }
    }
}