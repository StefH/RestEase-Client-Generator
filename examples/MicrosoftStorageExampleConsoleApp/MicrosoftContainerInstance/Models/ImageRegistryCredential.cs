using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class ImageRegistryCredential
    {
        public string Server { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Identity { get; set; }

        public string IdentityUrl { get; set; }
    }
}