namespace RestEaseClientCodeGeneratorVSIX.Options.RestEase
{
    public interface IRestEaseOptions
    {
        bool AddCredentials { get; set; }
        bool OverrideClientName { get; set; }
        bool UseInternalConstructors { get; set; }
        SyncMethodOptions SyncMethods { get; set; }
        bool UseDateTimeOffset { get; set; }
        bool ClientSideValidation { get; set; }
    }
}