using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class ManagementPolicyAction
    {
        public ManagementPolicyBaseBlob BaseBlob { get; set; }

        public ManagementPolicySnapShot Snapshot { get; set; }
    }
}