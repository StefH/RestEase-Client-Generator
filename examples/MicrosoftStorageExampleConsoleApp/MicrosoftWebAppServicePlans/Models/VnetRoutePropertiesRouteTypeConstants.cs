namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// The type of route this is:DEFAULT - By default, every app has routes to the local address ranges specified by RFC1918INHERITED - Routes inherited from the real Virtual Network routesSTATIC - Static route set on the app onlyThese values will be used for syncing an app's routes with those from a Virtual Network.
    /// </summary>
    public static class VnetRoutePropertiesRouteTypeConstants
    {
        public const string DEFAULT = "DEFAULT";

        public const string INHERITED = "INHERITED";

        public const string STATIC = "STATIC";
    }
}
