using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class Resource
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        public object Tags { get; set; }

        public string[] Zones { get; set; }
    }
}