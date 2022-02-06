using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the storage of the tokens if blob storage is used.
    /// </summary>
    public class BlobStorageTokenStore
    {
        /// <summary>
        /// The name of the app setting containing the SAS URL of the blob storage containing the tokens.
        /// </summary>
        public string SasUrlSettingName { get; set; }
    }
}