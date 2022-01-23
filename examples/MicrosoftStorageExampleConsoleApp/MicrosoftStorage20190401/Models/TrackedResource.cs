using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class TrackedResource : Resource
    {
        public Tags Tags { get; set; }

        public string Location { get; set; }

    }
}