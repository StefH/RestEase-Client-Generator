using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class Identity
    {
        public string PrincipalId { get; set; }

        public string TenantId { get; set; }

        public string Type { get; set; }

        public UserAssignedIdentities UserAssignedIdentities { get; set; }
    }
}