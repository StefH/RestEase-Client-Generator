using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.Cog.Models
{
    public class RankRequest
    {
        public object[] ContextFeatures { get; set; }

        public RankableAction[] Actions { get; set; }

        public string[] ExcludedActions { get; set; }

        public string EventId { get; set; }

        public bool DeferActivation { get; set; }
    }
}
