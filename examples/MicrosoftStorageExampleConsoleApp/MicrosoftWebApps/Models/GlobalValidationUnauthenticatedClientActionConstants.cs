namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The action to take when an unauthenticated client attempts to access the app.
    /// </summary>
    public static class GlobalValidationUnauthenticatedClientActionConstants
    {
        public const string RedirectToLoginPage = "RedirectToLoginPage";

        public const string AllowAnonymous = "AllowAnonymous";

        public const string Return401 = "Return401";

        public const string Return403 = "Return403";
    }
}
