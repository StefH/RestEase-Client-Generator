using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class ManagementPolicyProperties
    {
        public DateTime LastModifiedTime { get; set; }

        public ManagementPolicySchema Policy { get; set; }
    }
}