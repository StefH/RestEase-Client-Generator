using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class WebHookUpdateV21
    {
        public WebHookConfiguration Configuration { get; set; }

        public bool Active { get; set; }

        public string[] Events { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
