namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Defines what this IP filter will be used for. This is to support IP filtering on proxies.
    /// </summary>
    public static class IpSecurityRestrictionTagConstants
    {
        public const string Default = "Default";

        public const string XffProxy = "XffProxy";

        public const string ServiceTag = "ServiceTag";
    }
}
