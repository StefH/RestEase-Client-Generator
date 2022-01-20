using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class AzureFilesIdentityBasedAuthentication
    {
        public string DirectoryServiceOptions { get; set; }

        public ActiveDirectoryProperties ActiveDirectoryProperties { get; set; }

        public string DefaultSharePermission { get; set; }
    }
}