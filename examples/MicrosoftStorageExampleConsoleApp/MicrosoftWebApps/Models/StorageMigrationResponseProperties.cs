using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// StorageMigrationResponse resource specific properties
    /// </summary>
    public class StorageMigrationResponseProperties
    {
        /// <summary>
        /// When server starts the migration process, it will return an operation ID identifying that particular migration operation.
        /// </summary>
        public string OperationId { get; set; }
    }
}