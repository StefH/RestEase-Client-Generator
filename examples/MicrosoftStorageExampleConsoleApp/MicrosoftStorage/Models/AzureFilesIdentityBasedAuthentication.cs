using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class AzureFilesIdentityBasedAuthentication
    {
        public string DirectoryServiceOptions { get; set; }

        public ActiveDirectoryProperties ActiveDirectoryProperties { get; set; }

        public string DefaultSharePermission { get; set; }
    }
}