using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// ProcessModuleInfo resource specific properties
    /// </summary>
    public class ProcessModuleInfoProperties
    {
        /// <summary>
        /// Base address. Used as module identifier in ARM resource URI.
        /// </summary>
        public string BaseAddress { get; set; }

        /// <summary>
        /// File name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// HRef URI.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// File path.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Module memory size.
        /// </summary>
        public int ModuleMemorySize { get; set; }

        /// <summary>
        /// File version.
        /// </summary>
        public string FileVersion { get; set; }

        /// <summary>
        /// File description.
        /// </summary>
        public string FileDescription { get; set; }

        /// <summary>
        /// Product name.
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Product version.
        /// </summary>
        public string ProductVersion { get; set; }

        /// <summary>
        /// Is debug?
        /// </summary>
        public bool IsDebug { get; set; }

        /// <summary>
        /// Module language (locale).
        /// </summary>
        public string Language { get; set; }
    }
}