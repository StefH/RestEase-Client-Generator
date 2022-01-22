using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class BlobInventoryPolicy : Resource
    {
        public BlobInventoryPolicyProperties Properties { get; set; }

        public SystemData SystemData { get; set; }

    }
}