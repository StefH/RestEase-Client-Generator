using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Represents whether or not an app is cloneable.
    /// </summary>
    public class SiteCloneability
    {
        /// <summary>
        /// Name of app.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// List of features enabled on app that prevent cloning.
        /// </summary>
        public SiteCloneabilityCriterion[] BlockingFeatures { get; set; }

        /// <summary>
        /// List of features enabled on app that are non-blocking but cannot be cloned. The app can still be clonedbut the features in this list will not be set up on cloned app.
        /// </summary>
        public SiteCloneabilityCriterion[] UnsupportedFeatures { get; set; }

        /// <summary>
        /// List of blocking application characteristics.
        /// </summary>
        public SiteCloneabilityCriterion[] BlockingCharacteristics { get; set; }
    }
}