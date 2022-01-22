using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class ManagementPolicyRule
    {
        public bool Enabled { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public ManagementPolicyDefinition Definition { get; set; }
    }
}