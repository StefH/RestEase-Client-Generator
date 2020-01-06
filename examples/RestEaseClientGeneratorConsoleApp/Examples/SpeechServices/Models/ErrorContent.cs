using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class ErrorContent
    {
        public ErrorDetail[] Details { get; set; }

        public InnerError Innererror { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }

        public string Target { get; set; }
    }
}
