using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The environment variable to set within the container instance.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class EnvironmentVariable
    {
        /// <summary>
        /// The name of the environment variable.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the environment variable.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The value of the secure environment variable.
        /// </summary>
        public string SecureValue { get; set; }
    }
}