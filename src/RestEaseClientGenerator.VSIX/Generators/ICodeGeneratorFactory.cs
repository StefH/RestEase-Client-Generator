namespace RestEaseClientGenerator.VSIX.Generators
{
    public interface ICodeGeneratorFactory
    {
        ICodeGenerator Create(
            string defaultNamespace,
            string inputFileContents,
            string inputFilePath,
            SupportedLanguage language,
            SupportedCodeGenerator generator);
    }
}