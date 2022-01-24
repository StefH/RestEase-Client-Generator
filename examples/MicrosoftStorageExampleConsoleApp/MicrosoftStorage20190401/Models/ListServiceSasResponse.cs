using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
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