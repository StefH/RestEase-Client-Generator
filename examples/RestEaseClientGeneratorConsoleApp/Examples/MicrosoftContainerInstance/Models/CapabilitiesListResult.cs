using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class CapabilitiesListResult
    {
        public Capabilities[] Value { get; set; }

        public string NextLink { get; set; }
    }
}
