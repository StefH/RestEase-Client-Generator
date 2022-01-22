using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class ActiveDirectoryProperties
    {
        public string DomainName { get; set; }

        public string NetBiosDomainName { get; set; }

        public string ForestName { get; set; }

        public string DomainGuid { get; set; }

        public string DomainSid { get; set; }

        public string AzureStorageSid { get; set; }

        public string SamAccountName { get; set; }

        public string AccountType { get; set; }
    }
}