using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class Endpoints
    {
        public string Blob { get; set; }

        public string Queue { get; set; }

        public string Table { get; set; }

        public string File { get; set; }

        public string Web { get; set; }

        public string Dfs { get; set; }

        public StorageAccountMicrosoftEndpoints MicrosoftEndpoints { get; set; }

        public StorageAccountInternetEndpoints InternetEndpoints { get; set; }
    }
}