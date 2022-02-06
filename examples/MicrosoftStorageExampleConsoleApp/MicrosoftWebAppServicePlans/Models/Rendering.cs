using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Instructions for rendering the data
    /// </summary>
    public class Rendering
    {
        /// <summary>
        /// Rendering Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Title of data
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of the data that will help it be interpreted
        /// </summary>
        public string Description { get; set; }
    }
}