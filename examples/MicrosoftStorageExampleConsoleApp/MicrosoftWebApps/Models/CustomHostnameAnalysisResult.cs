using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Custom domain analysis.
    /// </summary>
    public class CustomHostnameAnalysisResult : ProxyOnlyResource 
    {
        /// <summary>
        /// CustomHostnameAnalysisResult resource specific properties
        /// </summary>
        public CustomHostnameAnalysisResultProperties Properties { get; set; }

    }
}