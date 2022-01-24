using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The parameters used when updating a storage account.
    /// </summary>
    public class StorageAccountPropertiesUpdateParameters
    {
        /// <summary>
        /// not-used
        /// </summary>
        public CustomDomain CustomDomain { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public Encryption Encryption { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public SasPolicy SasPolicy { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public KeyPolicy KeyPolicy { get; set; }

        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        /// </summary>
        public string AccessTier { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }

        /// <summary>
        /// Allows https traffic only to storage service if sets to true.
        /// </summary>
        public bool SupportsHttpsTrafficOnly { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public NetworkRuleSet NetworkAcls { get; set; }

        /// <summary>
        /// Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
        /// </summary>
        public string LargeFileSharesState { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public RoutingPreference RoutingPreference { get; set; }

        /// <summary>
        /// Allow or disallow public access to all blobs or containers in the storage account. The default interpretation is true for this property.
        /// </summary>
        public bool AllowBlobPublicAccess { get; set; }

        /// <summary>
        /// Set the minimum TLS version to be permitted on requests to storage. The default interpretation is TLS 1.0 for this property.
        /// </summary>
        public string MinimumTlsVersion { get; set; }

        /// <summary>
        /// Indicates whether the storage account permits requests to be authorized with the account access key via Shared Key. If false, then all requests, including shared access signatures, must be authorized with Azure Active Directory (Azure AD). The default value is null, which is equivalent to true.
        /// </summary>
        public bool AllowSharedKeyAccess { get; set; }

        /// <summary>
        /// Allow or disallow cross AAD tenant object replication. The default interpretation is true for this property.
        /// </summary>
        public bool AllowCrossTenantReplication { get; set; }
    }
}