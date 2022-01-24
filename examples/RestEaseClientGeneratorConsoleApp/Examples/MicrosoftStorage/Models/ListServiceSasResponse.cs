using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The List service SAS credentials operation response.
    /// </summary>
    public class ListServiceSasResponse
    {
        /// <summary>
        /// List service SAS credentials of specific resource.
        /// </summary>
        public string ServiceSasToken { get; set; }
    }
}