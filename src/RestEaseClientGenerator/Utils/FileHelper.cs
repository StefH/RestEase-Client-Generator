namespace RestEaseClientGenerator.Utils;

internal static class FileHelper
{
    internal static MemoryStream GetFileAsMemoryStream(string filePath)
    {
        using var fileStream = File.OpenRead(filePath);

        var memoryStream = new MemoryStream();
        fileStream.CopyTo(memoryStream);
        memoryStream.Position = 0;

        return memoryStream;
    }
}