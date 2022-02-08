namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Site load balancing.
    /// </summary>
    public static class SiteConfigLoadBalancingConstants
    {
        public const string WeightedRoundRobin = "WeightedRoundRobin";

        public const string LeastRequests = "LeastRequests";

        public const string LeastResponseTime = "LeastResponseTime";

        public const string WeightedTotalTraffic = "WeightedTotalTraffic";

        public const string RequestHash = "RequestHash";

        public const string PerSiteRoundRobin = "PerSiteRoundRobin";
    }
}
