using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class CloudErrorBody
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public string Target { get; set; }

        public object[] Details { get; set; }
    }
}
