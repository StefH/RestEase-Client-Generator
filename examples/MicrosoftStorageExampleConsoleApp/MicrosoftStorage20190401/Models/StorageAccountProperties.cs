using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// Properties of the storage account.
    /// </summary>
    public class StorageAccountProperties
    {
        /// <summary>
        /// Gets the status of the storage account at the time the operation was called.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public Endpoints PrimaryEndpoints { get; set; }

        /// <summary>
        /// Gets the location of the primary data center for the storage account.
        /// </summary>
        public string PrimaryLocation { get; set; }

        /// <summary>
        /// Gets the status indicating whether the primary location of the storage account is available or unavailable.
        /// </summary>
        public string StatusOfPrimary { get; set; }

        /// <summary>
        /// Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp is retained. This element is not returned if there has never been a failover instance. Only available if the accountType is Standard_GRS or Standard_RAGRS.
        /// </summary>
        public DateTime LastGeoFailoverTime { get; set; }

        /// <summary>
        /// Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS or Standard_RAGRS.
        /// </summary>
        public string SecondaryLocation { get; set; }

        /// <summary>
        /// Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available if the SKU name is Standard_GRS or Standard_RAGRS.
        /// </summary>
        public string StatusOfSecondary { get; set; }

        /// <summary>
        /// Gets the creation date and time of the storage account in UTC.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public CustomDomain CustomDomain { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public Endpoints SecondaryEndpoints { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public Encryption Encryption { get; set; }

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
        /// Account HierarchicalNamespace enabled if sets to true.
        /// </summary>
        public bool IsHnsEnabled { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public GeoReplicationStats GeoReplicationStats { get; set; }

        /// <summary>
        /// If the failover is in progress, the value will be true, otherwise, it will be null.
        /// </summary>
        public bool FailoverInProgress { get; set; }

        /// <summary>
        /// Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
        /// </summary>
        public string LargeFileSharesState { get; set; }

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
    }
}