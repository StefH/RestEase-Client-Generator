using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class BlobRestoreParameters
    {
        public DateTime TimeToRestore { get; set; }

        public object[] BlobRanges { get; set; }
    }
}