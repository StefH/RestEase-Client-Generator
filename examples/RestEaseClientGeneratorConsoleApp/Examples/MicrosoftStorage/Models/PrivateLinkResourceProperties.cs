using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class PrivateLinkResourceProperties
    {
        public string GroupId { get; set; }

        public string[] RequiredMembers { get; set; }

        public string[] RequiredZoneNames { get; set; }
    }
}