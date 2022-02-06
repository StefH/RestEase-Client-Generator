using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Response for a migration of app content request.
    /// </summary>
    public class StorageMigrationResponse : ProxyOnlyResource
    {
        /// <summary>
        /// StorageMigrationResponse resource specific properties
        /// </summary>
        public StorageMigrationResponseProperties Properties { get; set; }

    }
}