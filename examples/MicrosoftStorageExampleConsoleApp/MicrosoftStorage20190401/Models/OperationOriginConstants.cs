namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The intended executor of the operation; as in Resource Based Access Control (RBAC) and audit logs UX. Default value is "user,system"
    /// </summary>
    public static class OperationOriginConstants
    {
        public const string User = "user";
        public const string System = "system";
        public const string UserSystem = "user,system";
    }
}
