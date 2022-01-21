using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class Identity
    {
        public string PrincipalId { get; set; }

        public string TenantId { get; set; }

        public string Type { get; set; }

        public Dictionary<string, UserAssignedIdentity> UserAssignedIdentities { get; set; }
    }
}