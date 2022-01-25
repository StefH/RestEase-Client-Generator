using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Models.External;

public record GeneratedFile(FileType FileType, string Path, string Name, string ClassOrInterface, string Content);