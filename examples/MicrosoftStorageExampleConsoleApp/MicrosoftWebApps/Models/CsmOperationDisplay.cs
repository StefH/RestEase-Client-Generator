using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Meta data about operation used for display in portal.
    /// </summary>
    public class CsmOperationDisplay
    {
        public string Provider { get; set; }

        public string Resource { get; set; }

        public string Operation { get; set; }

        public string Description { get; set; }
    }
}