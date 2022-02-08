using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Set of data with rendering instructions
    /// </summary>
    public class DiagnosticData
    {
        /// <summary>
        /// Data Table which defines columns and raw row values
        /// </summary>
        public DataTableResponseObject Table { get; set; }

        /// <summary>
        /// Instructions for rendering the data
        /// </summary>
        public Rendering RenderingProperties { get; set; }
    }
}