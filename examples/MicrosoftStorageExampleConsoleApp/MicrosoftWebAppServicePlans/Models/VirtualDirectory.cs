using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Directory for virtual application.
    /// </summary>
    public class VirtualDirectory
    {
        /// <summary>
        /// Path to virtual application.
        /// </summary>
        public string VirtualPath { get; set; }

        /// <summary>
        /// Physical path.
        /// </summary>
        public string PhysicalPath { get; set; }
    }
}