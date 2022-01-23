using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class ActiveDirectoryProperties
    {
        public string DomainName { get; set; }

        public string NetBiosDomainName { get; set; }

        public string ForestName { get; set; }

        public string DomainGuid { get; set; }

        public string DomainSid { get; set; }

        public string AzureStorageSid { get; set; }
    }
}