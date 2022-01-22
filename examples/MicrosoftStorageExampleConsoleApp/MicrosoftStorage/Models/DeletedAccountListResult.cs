using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class DeletedAccountListResult
    {
        public DeletedAccount[] Value { get; set; }

        public string NextLink { get; set; }
    }
}