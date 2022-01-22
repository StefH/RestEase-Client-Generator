using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class BlobRestoreStatus
    {
        public string Status { get; set; }

        public string FailureReason { get; set; }

        public string RestoreId { get; set; }

        public BlobRestoreParameters Parameters { get; set; }
    }
}