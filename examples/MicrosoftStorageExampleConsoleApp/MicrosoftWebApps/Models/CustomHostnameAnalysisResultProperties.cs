using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// CustomHostnameAnalysisResult resource specific properties
    /// </summary>
    public class CustomHostnameAnalysisResultProperties
    {
        /// <summary>
        /// true if hostname is already verified; otherwise, false.
        /// </summary>
        public bool IsHostnameAlreadyVerified { get; set; }

        /// <summary>
        /// DNS verification test result.
        /// </summary>
        public string CustomDomainVerificationTest { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ErrorEntity CustomDomainVerificationFailureInfo { get; set; }

        /// <summary>
        /// true if there is a conflict on a scale unit; otherwise, false.
        /// </summary>
        public bool HasConflictOnScaleUnit { get; set; }

        /// <summary>
        /// true if there is a conflict across subscriptions; otherwise, false.
        /// </summary>
        public bool HasConflictAcrossSubscription { get; set; }

        /// <summary>
        /// Name of the conflicting app on scale unit if it's within the same subscription.
        /// </summary>
        public string ConflictingAppResourceId { get; set; }

        /// <summary>
        /// CName records controller can see for this hostname.
        /// </summary>
        public string[] CNameRecords { get; set; }

        /// <summary>
        /// TXT records controller can see for this hostname.
        /// </summary>
        public string[] TxtRecords { get; set; }

        /// <summary>
        /// A records controller can see for this hostname.
        /// </summary>
        public string[] ARecords { get; set; }

        /// <summary>
        /// Alternate CName records controller can see for this hostname.
        /// </summary>
        public string[] AlternateCNameRecords { get; set; }

        /// <summary>
        /// Alternate TXT records controller can see for this hostname.
        /// </summary>
        public string[] AlternateTxtRecords { get; set; }
    }
}