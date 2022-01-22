using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class DeletedAccountListResult
    {
        public DeletedAccount[] Value { get; set; }

        public string NextLink { get; set; }
    }
}