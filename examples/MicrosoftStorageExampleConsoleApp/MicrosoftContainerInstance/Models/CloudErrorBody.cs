using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class CloudErrorBody
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public string Target { get; set; }

        public CloudErrorBody[] Details { get; set; }
    }
}