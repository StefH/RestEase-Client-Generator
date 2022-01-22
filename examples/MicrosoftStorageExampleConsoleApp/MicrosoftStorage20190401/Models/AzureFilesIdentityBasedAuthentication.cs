using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class AzureFilesIdentityBasedAuthentication
    {
        public string DirectoryServiceOptions { get; set; }

        public ActiveDirectoryProperties ActiveDirectoryProperties { get; set; }
    }
}