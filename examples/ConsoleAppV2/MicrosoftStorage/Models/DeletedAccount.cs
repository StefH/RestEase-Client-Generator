using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Deleted storage account
    /// </summary>
    public class DeletedAccount : ProxyResource
    {
        /// <summary>
        /// Attributes of a deleted storage account.
        /// </summary>
        public DeletedAccountProperties Properties { get; set; }
    }
}