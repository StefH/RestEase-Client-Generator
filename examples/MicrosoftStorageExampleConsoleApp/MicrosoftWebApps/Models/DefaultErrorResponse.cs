using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// App Service error response.
    /// </summary>
    public class DefaultErrorResponse
    {
        /// <summary>
        /// Error model.
        /// </summary>
        public DefaultErrorResponseError Error { get; set; }
    }
}