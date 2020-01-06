using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class InnerError
    {
        public string Code { get; set; }

        public InnerError Innererror { get; set; }
    }
}
