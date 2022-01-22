using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
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

        public Endpoints SecondaryEndpoints { get; set; }

        public Encryption Encryption { get; set; }

        public string AccessTier { get; set; }

        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }

        public bool SupportsHttpsTrafficOnly { get; set; }

        public NetworkRuleSet NetworkAcls { get; set; }

        public bool IsHnsEnabled { get; set; }

        public GeoReplicationStats GeoReplicationStats { get; set; }

        public bool FailoverInProgress { get; set; }

        public string LargeFileSharesState { get; set; }

        public bool AllowBlobPublicAccess { get; set; }

        public string MinimumTlsVersion { get; set; }

        public bool AllowSharedKeyAccess { get; set; }
    }
}