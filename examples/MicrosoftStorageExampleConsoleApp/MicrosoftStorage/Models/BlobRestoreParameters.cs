using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class BlobRestoreParameters
    {
        public DateTime TimeToRestore { get; set; }

        public BlobRestoreRange[] BlobRanges { get; set; }
    }
}