using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// SitePhpErrorLogFlag resource specific properties
    /// </summary>
    public class SitePhpErrorLogFlagProperties
    {
        /// <summary>
        /// Local log_errors setting.
        /// </summary>
        public string LocalLogErrors { get; set; }

        /// <summary>
        /// Master log_errors setting.
        /// </summary>
        public string MasterLogErrors { get; set; }

        /// <summary>
        /// Local log_errors_max_len setting.
        /// </summary>
        public string LocalLogErrorsMaxLength { get; set; }

        /// <summary>
        /// Master log_errors_max_len setting.
        /// </summary>
        public string MasterLogErrorsMaxLength { get; set; }
    }
}