using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// MySQL migration status.
    /// </summary>
    public class MigrateMySqlStatus : ProxyOnlyResource 
    {
        /// <summary>
        /// MigrateMySqlStatus resource specific properties
        /// </summary>
        public MigrateMySqlStatusProperties Properties { get; set; }

    }
}