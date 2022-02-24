using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Slot Config names azure resource.
    /// </summary>
    public class SlotConfigNamesResource : ProxyOnlyResource 
    {
        /// <summary>
        /// Names for connection strings, application settings, and external Azure storage account configurationidentifiers to be marked as sticky to the deployment slot and not moved during a swap operation.This is valid for all deployment slots in an app.
        /// </summary>
        public SlotConfigNames Properties { get; set; }

    }
}