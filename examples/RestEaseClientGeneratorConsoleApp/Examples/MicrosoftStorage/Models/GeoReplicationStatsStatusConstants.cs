namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location is temporarily unavailable.
    /// </summary>
    public static class GeoReplicationStatsStatusConstants
    {
        public const string Live = "Live";

        public const string Bootstrap = "Bootstrap";

        public const string Unavailable = "Unavailable";
    }
}
