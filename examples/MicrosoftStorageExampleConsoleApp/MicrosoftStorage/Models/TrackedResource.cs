using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class TrackedResource : Resource
    {
        public Tags Tags { get; set; }

        public string Location { get; set; }

    }
}