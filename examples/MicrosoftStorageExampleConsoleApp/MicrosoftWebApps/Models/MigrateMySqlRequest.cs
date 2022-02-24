using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// MySQL migration request.
    /// </summary>
    public class MigrateMySqlRequest : ProxyOnlyResource 
    {
        /// <summary>
        /// MigrateMySqlRequest resource specific properties
        /// </summary>
        public MigrateMySqlRequestProperties Properties { get; set; }

    }
}