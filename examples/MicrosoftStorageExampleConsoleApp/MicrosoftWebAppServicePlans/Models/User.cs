using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// User credentials used for publishing activity.
    /// </summary>
    public class User : ProxyOnlyResource
    {
        /// <summary>
        /// User resource specific properties
        /// </summary>
        public UserProperties Properties { get; set; }

    }
}