using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Class representing Response from Detector
    /// </summary>
    public class DetectorResponse : ProxyOnlyResource 
    {
        /// <summary>
        /// DetectorResponse resource specific properties
        /// </summary>
        public DetectorResponseProperties Properties { get; set; }

    }
}