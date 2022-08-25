using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Settings properties for Active Directory (AD).
    /// </summary>
    public class ActiveDirectoryProperties
    {
        /// <summary>
        /// Specifies the primary domain that the AD DNS server is authoritative for.
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// Specifies the NetBIOS domain name.
        /// </summary>
        public string NetBiosDomainName { get; set; }

        /// <summary>
        /// Specifies the Active Directory forest to get.
        /// </summary>
        public string ForestName { get; set; }

        /// <summary>
        /// Specifies the domain GUID.
        /// </summary>
        public string DomainGuid { get; set; }

        /// <summary>
        /// Specifies the security identifier (SID).
        /// </summary>
        public string DomainSid { get; set; }

        /// <summary>
        /// Specifies the security identifier (SID) for Azure Storage.
        /// </summary>
        public string AzureStorageSid { get; set; }
    }
}