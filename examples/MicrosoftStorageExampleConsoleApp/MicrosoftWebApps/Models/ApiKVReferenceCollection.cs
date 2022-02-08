using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    public class ApiKVReferenceCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public ApiKVReference[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}