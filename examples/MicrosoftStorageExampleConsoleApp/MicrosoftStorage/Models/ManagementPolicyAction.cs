using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class ManagementPolicyAction
    {
        public ManagementPolicyBaseBlob BaseBlob { get; set; }

        public ManagementPolicySnapShot Snapshot { get; set; }

        public ManagementPolicyVersion Version { get; set; }
    }
}