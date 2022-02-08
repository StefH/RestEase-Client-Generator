using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Virtual application in an app.
    /// </summary>
    public class VirtualApplication
    {
        /// <summary>
        /// Virtual path.
        /// </summary>
        public string VirtualPath { get; set; }

        /// <summary>
        /// Physical path.
        /// </summary>
        public string PhysicalPath { get; set; }

        /// <summary>
        /// true if preloading is enabled; otherwise, false.
        /// </summary>
        public bool PreloadEnabled { get; set; }

        /// <summary>
        /// Virtual directories for virtual application.
        /// </summary>
        public VirtualDirectory[] VirtualDirectories { get; set; }
    }
}