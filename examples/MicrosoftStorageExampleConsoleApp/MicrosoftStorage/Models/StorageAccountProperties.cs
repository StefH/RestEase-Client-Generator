using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class StorageAccountProperties
    {
        public string ProvisioningState { get; set; }

        public Endpoints PrimaryEndpoints { get; set; }

        public string PrimaryLocation { get; set; }

        public string StatusOfPrimary { get; set; }

        public DateTime LastGeoFailoverTime { get; set; }

        public string SecondaryLocation { get; set; }

        public string StatusOfSecondary { get; set; }

        public DateTime CreationTime { get; set; }

        public CustomDomain CustomDomain { get; set; }

        public SasPolicy SasPolicy { get; set; }

        public KeyPolicy KeyPolicy { get; set; }

        public KeyCreationTime KeyCreationTime { get; set; }

        public Endpoints SecondaryEndpoints { get; set; }

        public Encryption Encryption { get; set; }

        public string AccessTier { get; set; }

        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }

        public bool SupportsHttpsTrafficOnly { get; set; }

        public NetworkRuleSet NetworkAcls { get; set; }

        public bool IsSftpEnabled { get; set; }

        public bool IsLocalUserEnabled { get; set; }

        public bool IsHnsEnabled { get; set; }

        public GeoReplicationStats GeoReplicationStats { get; set; }

        public bool FailoverInProgress { get; set; }

        public string LargeFileSharesState { get; set; }

        public DefinitionsPrivateEndpointConnection[] PrivateEndpointConnections { get; set; }

        public RoutingPreference RoutingPreference { get; set; }

        public BlobRestoreStatus BlobRestoreStatus { get; set; }

        public bool AllowBlobPublicAccess { get; set; }

        public string MinimumTlsVersion { get; set; }

        public bool AllowSharedKeyAccess { get; set; }

        public bool IsNfsV3Enabled { get; set; }

        public bool AllowCrossTenantReplication { get; set; }

        public bool DefaultToOAuthAuthentication { get; set; }

        public string PublicNetworkAccess { get; set; }

        public ImmutableStorageAccount ImmutableStorageWithVersioning { get; set; }

        public string AllowedCopyScope { get; set; }
    }
}