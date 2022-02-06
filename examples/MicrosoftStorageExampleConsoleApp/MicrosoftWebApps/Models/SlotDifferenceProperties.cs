using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// SlotDifference resource specific properties
    /// </summary>
    public class SlotDifferenceProperties
    {
        /// <summary>
        /// Level of the difference: Information, Warning or Error.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// The type of the setting: General, AppSetting or ConnectionString.
        /// </summary>
        public string SettingType { get; set; }

        /// <summary>
        /// Rule that describes how to process the setting difference during a slot swap.
        /// </summary>
        public string DiffRule { get; set; }

        /// <summary>
        /// Name of the setting.
        /// </summary>
        public string SettingName { get; set; }

        /// <summary>
        /// Value of the setting in the current slot.
        /// </summary>
        public string ValueInCurrentSlot { get; set; }

        /// <summary>
        /// Value of the setting in the target slot.
        /// </summary>
        public string ValueInTargetSlot { get; set; }

        /// <summary>
        /// Description of the setting difference.
        /// </summary>
        public string Description { get; set; }
    }
}