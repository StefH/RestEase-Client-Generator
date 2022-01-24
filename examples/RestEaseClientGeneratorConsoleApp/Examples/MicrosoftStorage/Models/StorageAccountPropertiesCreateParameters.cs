using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The parameters used to create the storage account.
    /// </summary>
    public class StorageAccountPropertiesCreateParameters
    {
        /// <summary>
        /// Restrict copy to and from Storage Accounts within an AAD tenant or with Private Links to the same VNet.
        /// </summary>
        public string AllowedCopyScope { get; set; }

        /// <summary>
        /// Allow or disallow public network access to Storage Account. Value is optional but if passed in, must be 'Enabled' or 'Disabled'.
        /// </summary>
        public string PublicNetworkAccess { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public SasPolicy SasPolicy { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public KeyPolicy KeyPolicy { get; set; }

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
        public NetworkRuleSet NetworkAcls { get; set; }

        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        /// </summary>
        public string AccessTier { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }

        /// <summary>
        /// Allows https traffic only to storage service if sets to true. The default value is true since API version 2019-04-01.
        /// </summary>
        public bool SupportsHttpsTrafficOnly { get; set; }

        /// <summary>
        /// Enables Secure File Transfer Protocol, if set to true
        /// </summary>
        public bool IsSftpEnabled { get; set; }

        /// <summary>
        /// Enables local users feature, if set to true
        /// </summary>
        public bool IsLocalUserEnabled { get; set; }

        /// <summary>
        /// Account HierarchicalNamespace enabled if sets to true.
        /// </summary>
        public bool IsHnsEnabled { get; set; }

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
        /// NFS 3.0 protocol support enabled if set to true.
        /// </summary>
        public bool IsNfsV3Enabled { get; set; }

        /// <summary>
        /// Allow or disallow cross AAD tenant object replication. The default interpretation is true for this property.
        /// </summary>
        public bool AllowCrossTenantReplication { get; set; }

        /// <summary>
        /// A boolean flag which indicates whether the default authentication is OAuth or not. The default interpretation is false for this property.
        /// </summary>
        public bool DefaultToOAuthAuthentication { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ImmutableStorageAccount ImmutableStorageWithVersioning { get; set; }
    }
}