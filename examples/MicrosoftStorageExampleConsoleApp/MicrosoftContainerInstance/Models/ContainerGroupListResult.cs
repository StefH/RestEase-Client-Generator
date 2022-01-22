using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class ContainerGroupListResult
    {
        public ContainerGroup[] Value { get; set; }

        public string NextLink { get; set; }
    }
}