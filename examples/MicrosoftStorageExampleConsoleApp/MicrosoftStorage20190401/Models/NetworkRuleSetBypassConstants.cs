namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.
    /// </summary>
    public static class NetworkRuleSetBypassConstants
    {
        public const string None = "None";
        public const string Logging = "Logging";
        public const string Metrics = "Metrics";
        public const string AzureServices = "AzureServices";
    }
}
