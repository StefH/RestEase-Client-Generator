namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// This composes with ClientCertEnabled setting.- ClientCertEnabled: false means ClientCert is ignored.- ClientCertEnabled: true and ClientCertMode: Required means ClientCert is required.- ClientCertEnabled: true and ClientCertMode: Optional means ClientCert is optional or accepted.
    /// </summary>
    public static class SitePatchResourcePropertiesClientCertModeConstants
    {
        public const string Required = "Required";

        public const string Optional = "Optional";

        public const string OptionalInteractiveUser = "OptionalInteractiveUser";
    }
}
