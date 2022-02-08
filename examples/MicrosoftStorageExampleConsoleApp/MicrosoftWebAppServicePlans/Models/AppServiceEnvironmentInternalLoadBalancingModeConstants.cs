namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Specifies which endpoints to serve internally in the Virtual Network for the App Service Environment.
    /// </summary>
    public static class AppServiceEnvironmentInternalLoadBalancingModeConstants
    {
        public const string None = "None";

        public const string Web = "Web";

        public const string Publishing = "Publishing";

        public const string WebPublishing = "Web, Publishing";
    }
}
