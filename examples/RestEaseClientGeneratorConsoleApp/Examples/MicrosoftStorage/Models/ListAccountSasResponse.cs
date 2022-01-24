using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The List SAS credentials operation response.
    /// </summary>
    public class ListAccountSasResponse
    {
        /// <summary>
        /// List SAS credentials of storage account.
        /// </summary>
        public string AccountSasToken { get; set; }
    }
}