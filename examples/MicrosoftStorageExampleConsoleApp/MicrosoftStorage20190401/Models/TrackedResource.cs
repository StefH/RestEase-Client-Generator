using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The resource model definition for an Azure Resource Manager tracked top level resource which has 'tags' and a 'location'
    /// </summary>
    public class TrackedResource : Resource
    {
        /// <summary>
        /// The resource model definition for an Azure Resource Manager tracked top level resource which has 'tags' and a 'location'
        /// </summary>
        public Tags Tags { get; set; }

        /// <summary>
        /// The geo-location where the resource lives
        /// </summary>
        public string Location { get; set; }

    }
}