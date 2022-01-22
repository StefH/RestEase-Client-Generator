using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class ErrorResponse
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public string Target { get; set; }

        public ErrorResponse[] Details { get; set; }

        public ErrorAdditionalInfo[] AdditionalInfo { get; set; }
    }
}