using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The cached image and OS type.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class CachedImages
    {
        /// <summary>
        /// The OS type of the cached image.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        /// The cached image name.
        /// </summary>
        public string Image { get; set; }
    }
}