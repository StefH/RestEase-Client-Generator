using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The properties of the volume mount.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class VolumeMount
    {
        /// <summary>
        /// The name of the volume mount.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The path within the container where the volume should be mounted. Must not contain colon (:).
        /// </summary>
        public string MountPath { get; set; }

        /// <summary>
        /// The flag indicating whether the volume mount is read-only.
        /// </summary>
        public bool ReadOnly { get; set; }
    }
}