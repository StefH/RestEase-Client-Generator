using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class SystemData
    {
        public string CreatedBy { get; set; }

        public string CreatedByType { get; set; }

        public DateTime CreatedAt { get; set; }

        public string LastModifiedBy { get; set; }

        public string LastModifiedByType { get; set; }

        public DateTime LastModifiedAt { get; set; }
    }
}