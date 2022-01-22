using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class BlobInventoryPolicyProperties
    {
        public DateTime LastModifiedTime { get; set; }

        public BlobInventoryPolicySchema Policy { get; set; }
    }
}