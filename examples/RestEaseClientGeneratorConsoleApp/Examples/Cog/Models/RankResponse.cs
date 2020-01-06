using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.Cog.Models
{
    public class RankResponse
    {
        public RankedAction[] Ranking { get; set; }

        public string EventId { get; set; }

        public string RewardActionId { get; set; }
    }
}
