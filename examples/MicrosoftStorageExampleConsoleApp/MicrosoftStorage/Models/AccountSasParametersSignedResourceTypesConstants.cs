namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The signed resource types that are accessible with the account SAS. Service (s): Access to service-level APIs; Container (c): Access to container-level APIs; Object (o): Access to object-level APIs for blobs, queue messages, table entities, and files.
    /// </summary>
    public static class AccountSasParametersSignedResourceTypesConstants
    {
        public const string S = "s";
        public const string C = "c";
        public const string O = "o";
    }
}
