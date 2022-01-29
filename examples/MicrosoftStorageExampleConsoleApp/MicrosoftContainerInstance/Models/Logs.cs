using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The logs.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class Logs
    {
        /// <summary>
        /// The content of the log.
        /// </summary>
        public string Content { get; set; }
    }
}