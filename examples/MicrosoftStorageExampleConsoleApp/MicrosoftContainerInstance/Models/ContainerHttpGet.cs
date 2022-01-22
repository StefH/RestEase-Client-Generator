using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class ContainerHttpGet
    {
        public string Path { get; set; }

        public int Port { get; set; }

        public string Scheme { get; set; }

        public HttpHeader[] HttpHeaders { get; set; }
    }
}