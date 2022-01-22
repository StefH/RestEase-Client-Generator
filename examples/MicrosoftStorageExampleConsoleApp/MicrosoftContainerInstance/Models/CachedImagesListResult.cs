using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class CachedImagesListResult
    {
        public CachedImages[] Value { get; set; }

        public string NextLink { get; set; }
    }
}