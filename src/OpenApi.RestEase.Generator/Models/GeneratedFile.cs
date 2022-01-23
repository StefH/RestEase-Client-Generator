using OpenApi.RestEase.Generator.Types;

namespace OpenApi.RestEase.Generator.Models;

public record GeneratedFile(FileType FileType, string Path, string Name, string ClassOrInterface, string Content);