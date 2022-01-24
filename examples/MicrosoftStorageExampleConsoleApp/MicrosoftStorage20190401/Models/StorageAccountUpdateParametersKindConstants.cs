namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.
    /// </summary>
    public static class StorageAccountUpdateParametersKindConstants
    {
        public const string Storage = "Storage";

        public const string StorageV2 = "StorageV2";

        public const string BlobStorage = "BlobStorage";

        public const string FileStorage = "FileStorage";

        public const string BlockBlobStorage = "BlockBlobStorage";
    }
}
