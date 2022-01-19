using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class ContainerHttpGet
    {
        public string Path { get; set; }

        public int Port { get; set; }

        public string Scheme { get; set; }

        public HttpHeader[] HttpHeaders { get; set; }
    }
}
