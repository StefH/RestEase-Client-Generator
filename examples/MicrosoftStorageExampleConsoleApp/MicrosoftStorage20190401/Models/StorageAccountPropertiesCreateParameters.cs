using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class StorageAccountPropertiesCreateParameters
    {
        public CustomDomain CustomDomain { get; set; }

        public Encryption Encryption { get; set; }

        public NetworkRuleSet NetworkAcls { get; set; }

        public string AccessTier { get; set; }

        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }

        public bool SupportsHttpsTrafficOnly { get; set; }

        public bool IsHnsEnabled { get; set; }

        public string LargeFileSharesState { get; set; }

        public bool AllowBlobPublicAccess { get; set; }

        public string MinimumTlsVersion { get; set; }

        public bool AllowSharedKeyAccess { get; set; }
    }
}