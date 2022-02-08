using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Deployment slot parameters.
    /// </summary>
    public class CsmSlotEntity
    {
        /// <summary>
        /// Destination deployment slot during swap operation.
        /// </summary>
        public string TargetSlot { get; set; }

        /// <summary>
        /// true to preserve Virtual Network to the slot during swap; otherwise, false.
        /// </summary>
        public bool PreserveVnet { get; set; }
    }
}