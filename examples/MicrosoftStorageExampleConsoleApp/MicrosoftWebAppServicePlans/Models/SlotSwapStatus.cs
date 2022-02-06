using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// The status of the last successful slot swap operation.
    /// </summary>
    public class SlotSwapStatus
    {
        /// <summary>
        /// The time the last successful slot swap completed.
        /// </summary>
        public DateTime TimestampUtc { get; set; }

        /// <summary>
        /// The source slot of the last swap operation.
        /// </summary>
        public string SourceSlotName { get; set; }

        /// <summary>
        /// The destination slot of the last swap operation.
        /// </summary>
        public string DestinationSlotName { get; set; }
    }
}