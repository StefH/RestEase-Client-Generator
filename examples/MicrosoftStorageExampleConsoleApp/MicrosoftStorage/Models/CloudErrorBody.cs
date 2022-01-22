using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class CloudErrorBody
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public string Target { get; set; }

        public CloudErrorBody[] Details { get; set; }
    }
}