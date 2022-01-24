using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// List storage account local users.
    /// </summary>
    public class LocalUsers
    {
        /// <summary>
        /// The local users associated with the storage account.
        /// </summary>
        public LocalUser[] Value { get; set; }
    }
}