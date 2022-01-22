using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class LocalUser : Resource
    {
        public LocalUserProperties Properties { get; set; }

        public SystemData SystemData { get; set; }

    }
}