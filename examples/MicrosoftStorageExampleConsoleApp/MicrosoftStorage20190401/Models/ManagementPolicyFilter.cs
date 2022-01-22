using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class ManagementPolicyFilter
    {
        public string[] PrefixMatch { get; set; }

        public string[] BlobTypes { get; set; }
    }
}