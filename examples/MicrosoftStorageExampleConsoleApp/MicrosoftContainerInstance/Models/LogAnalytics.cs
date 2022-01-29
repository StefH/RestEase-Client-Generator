using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// Container group log analytics information.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class LogAnalytics
    {
        /// <summary>
        /// The workspace id for log analytics
        /// </summary>
        public string WorkspaceId { get; set; }

        /// <summary>
        /// The workspace key for log analytics
        /// </summary>
        public string WorkspaceKey { get; set; }

        /// <summary>
        /// The log type to be used.
        /// </summary>
        public string LogType { get; set; }

        /// <summary>
        /// Metadata for log analytics.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// The workspace resource id for log analytics
        /// </summary>
        public string WorkspaceResourceId { get; set; }
    }
}