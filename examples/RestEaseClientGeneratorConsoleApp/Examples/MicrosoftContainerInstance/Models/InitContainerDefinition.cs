using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class InitContainerDefinition
    {
        public string Name { get; set; }

        public InitContainerPropertiesDefinition Properties { get; set; }
    }
}
