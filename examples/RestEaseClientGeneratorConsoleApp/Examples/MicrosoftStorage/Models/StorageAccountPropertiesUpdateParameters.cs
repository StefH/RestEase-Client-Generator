using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class StorageAccountPropertiesUpdateParameters
    {
        public CustomDomain CustomDomain { get; set; }

        public Encryption Encryption { get; set; }

        public SasPolicy SasPolicy { get; set; }

        public KeyPolicy KeyPolicy { get; set; }

        public string AccessTier { get; set; }

        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }

        public bool SupportsHttpsTrafficOnly { get; set; }

        public bool IsSftpEnabled { get; set; }

        public bool IsLocalUserEnabled { get; set; }

        public NetworkRuleSet NetworkAcls { get; set; }

        public string LargeFileSharesState { get; set; }

        public RoutingPreference RoutingPreference { get; set; }

        public bool AllowBlobPublicAccess { get; set; }

        public string MinimumTlsVersion { get; set; }

        public bool AllowSharedKeyAccess { get; set; }

        public bool AllowCrossTenantReplication { get; set; }

        public bool DefaultToOAuthAuthentication { get; set; }

        public string PublicNetworkAccess { get; set; }

        public ImmutableStorageAccount ImmutableStorageWithVersioning { get; set; }

        public string AllowedCopyScope { get; set; }
    }
}