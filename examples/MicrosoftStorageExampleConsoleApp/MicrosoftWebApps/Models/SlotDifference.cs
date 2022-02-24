using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// A setting difference between two deployment slots of an app.
    /// </summary>
    public class SlotDifference : ProxyOnlyResource 
    {
        /// <summary>
        /// SlotDifference resource specific properties
        /// </summary>
        public SlotDifferenceProperties Properties { get; set; }

    }
}