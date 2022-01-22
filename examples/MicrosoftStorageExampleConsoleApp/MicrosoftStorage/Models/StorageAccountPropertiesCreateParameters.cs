using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class StorageAccountPropertiesCreateParameters
    {
        public string AllowedCopyScope { get; set; }

        public string PublicNetworkAccess { get; set; }

        public SasPolicy SasPolicy { get; set; }

        public KeyPolicy KeyPolicy { get; set; }

        public CustomDomain CustomDomain { get; set; }

        public Encryption Encryption { get; set; }

        public NetworkRuleSet NetworkAcls { get; set; }

        public string AccessTier { get; set; }

        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }

        public bool SupportsHttpsTrafficOnly { get; set; }

        public bool IsSftpEnabled { get; set; }

        public bool IsLocalUserEnabled { get; set; }

        public bool IsHnsEnabled { get; set; }

        public string LargeFileSharesState { get; set; }

        public RoutingPreference RoutingPreference { get; set; }

        public bool AllowBlobPublicAccess { get; set; }

        public string MinimumTlsVersion { get; set; }

        public bool AllowSharedKeyAccess { get; set; }

        public bool IsNfsV3Enabled { get; set; }

        public bool AllowCrossTenantReplication { get; set; }

        public bool DefaultToOAuthAuthentication { get; set; }

        public ImmutableStorageAccount ImmutableStorageWithVersioning { get; set; }
    }
}