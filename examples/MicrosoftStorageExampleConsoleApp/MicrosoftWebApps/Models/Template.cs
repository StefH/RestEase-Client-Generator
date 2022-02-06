using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Container App versioned application definition.Defines the desired state of an immutable revision.Any changes to this section Will result in a new revision being created
    /// </summary>
    public class Template
    {
        /// <summary>
        /// User friendly suffix that is appended to the revision name
        /// </summary>
        public string RevisionSuffix { get; set; }

        /// <summary>
        /// List of container definitions for the Container App.
        /// </summary>
        public Container[] Containers { get; set; }

        /// <summary>
        /// Container App scaling configurations.
        /// </summary>
        public Scale Scale { get; set; }

        /// <summary>
        /// Container App Dapr configuration.
        /// </summary>
        public Dapr Dapr { get; set; }
    }
}