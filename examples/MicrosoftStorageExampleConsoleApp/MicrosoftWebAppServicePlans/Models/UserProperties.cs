using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// User resource specific properties
    /// </summary>
    public class UserProperties
    {
        /// <summary>
        /// Username used for publishing.
        /// </summary>
        public string PublishingUserName { get; set; }

        /// <summary>
        /// Password used for publishing.
        /// </summary>
        public string PublishingPassword { get; set; }

        /// <summary>
        /// Password hash used for publishing.
        /// </summary>
        public string PublishingPasswordHash { get; set; }

        /// <summary>
        /// Password hash salt used for publishing.
        /// </summary>
        public string PublishingPasswordHashSalt { get; set; }

        /// <summary>
        /// Url of SCM site.
        /// </summary>
        public string ScmUri { get; set; }
    }
}