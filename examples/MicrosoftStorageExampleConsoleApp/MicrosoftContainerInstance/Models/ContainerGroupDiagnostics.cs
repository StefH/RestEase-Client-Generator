using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// Container group diagnostic information.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class ContainerGroupDiagnostics
    {
        /// <summary>
        /// Container group log analytics information.
        /// </summary>
        public LogAnalytics LogAnalytics { get; set; }
    }
}