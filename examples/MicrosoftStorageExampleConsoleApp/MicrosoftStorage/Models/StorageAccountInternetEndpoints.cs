using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class StorageAccountInternetEndpoints
    {
        public string Blob { get; set; }

        public string File { get; set; }

        public string Web { get; set; }

        public string Dfs { get; set; }
    }
}