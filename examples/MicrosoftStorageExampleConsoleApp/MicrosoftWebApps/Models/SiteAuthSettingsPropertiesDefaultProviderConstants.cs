namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The default authentication provider to use when multiple providers are configured.This setting is only needed if multiple providers are configured and the unauthenticated clientaction is set to "RedirectToLoginPage".
    /// </summary>
    public static class SiteAuthSettingsPropertiesDefaultProviderConstants
    {
        public const string AzureActiveDirectory = "AzureActiveDirectory";

        public const string Facebook = "Facebook";

        public const string Google = "Google";

        public const string MicrosoftAccount = "MicrosoftAccount";

        public const string Twitter = "Twitter";

        public const string Github = "Github";
    }
}
