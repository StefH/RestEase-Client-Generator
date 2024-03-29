using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
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
        /// The URIs that are used to perform a retrieval of a public blob, queue, table, web or dfs object.
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
        /// The custom domain assigned to this storage account. This can be set via Update.
        /// </summary>
        public CustomDomain CustomDomain { get; set; }

        /// <summary>
        /// SasPolicy assigned to the storage account.
        /// </summary>
        public SasPolicy SasPolicy { get; set; }

        /// <summary>
        /// KeyPolicy assigned to the storage account.
        /// </summary>
        public KeyPolicy KeyPolicy { get; set; }

        /// <summary>
        /// Storage account keys creation time.
        /// </summary>
        public KeyCreationTime KeyCreationTime { get; set; }

        /// <summary>
        /// The URIs that are used to perform a retrieval of a public blob, queue, table, web or dfs object.
        /// </summary>
        public Endpoints SecondaryEndpoints { get; set; }

        /// <summary>
        /// The encryption settings on the storage account.
        /// </summary>
        public Encryption Encryption { get; set; }

        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        /// </summary>
        public string AccessTier { get; set; }

        /// <summary>
        /// Settings for Azure Files identity based authentication.
        /// </summary>
        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }

        /// <summary>
        /// Allows https traffic only to storage service if sets to true.
        /// </summary>
        public bool SupportsHttpsTrafficOnly { get; set; }

        /// <summary>
        /// Network rule set
        /// </summary>
        public NetworkRuleSet NetworkAcls { get; set; }

        /// <summary>
        /// Account HierarchicalNamespace enabled if sets to true.
        /// </summary>
        public bool IsHnsEnabled { get; set; }

        /// <summary>
        /// Statistics related to replication for storage account's Blob, Table, Queue and File services. It is only available when geo-redundant replication is enabled for the storage account.
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
        /// List of private endpoint connection associated with the specified storage account
        /// </summary>
        public PrivateEndpointConnection[] PrivateEndpointConnections { get; set; }

        /// <summary>
        /// Routing preference defines the type of network, either microsoft or internet routing to be used to deliver the user data, the default option is microsoft routing
        /// </summary>
        public RoutingPreference RoutingPreference { get; set; }

        /// <summary>
        /// Blob restore status.
        /// </summary>
        public BlobRestoreStatus BlobRestoreStatus { get; set; }

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
    }
}