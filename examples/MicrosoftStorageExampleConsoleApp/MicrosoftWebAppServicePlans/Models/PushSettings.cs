using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Push settings for the App.
    /// </summary>
    public class PushSettings : ProxyOnlyResource
    {
        /// <summary>
        /// PushSettings resource specific properties
        /// </summary>
        public PushSettingsProperties Properties { get; set; }

    }
}