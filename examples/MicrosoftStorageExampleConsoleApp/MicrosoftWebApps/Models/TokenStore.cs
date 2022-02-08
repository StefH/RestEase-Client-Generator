using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the token store.
    /// </summary>
    public class TokenStore
    {
        /// <summary>
        /// true to durably store platform-specific security tokens that are obtained during login flows; otherwise, false. The default is false.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The number of hours after session token expiration that a session token can be used tocall the token refresh API. The default is 72 hours.
        /// </summary>
        public double TokenRefreshExtensionHours { get; set; }

        /// <summary>
        /// The configuration settings of the storage of the tokens if a file system is used.
        /// </summary>
        public FileSystemTokenStore FileSystem { get; set; }

        /// <summary>
        /// The configuration settings of the storage of the tokens if blob storage is used.
        /// </summary>
        public BlobStorageTokenStore AzureBlobStorage { get; set; }
    }
}