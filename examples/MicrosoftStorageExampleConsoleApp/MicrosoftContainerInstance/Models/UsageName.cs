using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The name object of the resource
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class UsageName
    {
        /// <summary>
        /// The name of the resource
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The localized name of the resource
        /// </summary>
        public string LocalizedValue { get; set; }
    }
}