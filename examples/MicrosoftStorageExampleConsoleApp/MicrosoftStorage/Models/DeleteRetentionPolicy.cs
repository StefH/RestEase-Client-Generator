using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class DeleteRetentionPolicy
    {
        public bool Enabled { get; set; }

        public int Days { get; set; }
    }
}