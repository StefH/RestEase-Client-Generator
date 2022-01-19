using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class OperationListResult
    {
        public Operation[] Value { get; set; }

        public string NextLink { get; set; }
    }
}
