using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class ManagementPolicyDefinition
    {
        public ManagementPolicyAction Actions { get; set; }

        public ManagementPolicyFilter Filters { get; set; }
    }
}