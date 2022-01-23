using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The init container definition.
    /// </summary>
    public class InitContainerDefinition
    {
        /// <summary>
        /// The name for the init container.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public InitContainerPropertiesDefinition Properties { get; set; }
    }
}