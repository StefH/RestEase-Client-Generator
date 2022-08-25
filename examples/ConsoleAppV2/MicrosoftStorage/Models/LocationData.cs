using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Metadata pertaining to the geographic location of the resource.
    /// </summary>
    public class LocationData
    {
        /// <summary>
        /// A canonical name for the geographic or physical location.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The city or locality where the resource is located.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The district, state, or province where the resource is located.
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// The country or region where the resource is located
        /// </summary>
        public string CountryOrRegion { get; set; }
    }
}