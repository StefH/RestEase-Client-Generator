using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class EncryptionServices
    {
        public EncryptionService Blob { get; set; }

        public EncryptionService File { get; set; }

        public EncryptionService Table { get; set; }

        public EncryptionService Queue { get; set; }
    }
}