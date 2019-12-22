namespace RestEaseClientCodeGeneratorVSIX.Generators
{
    public interface ICodeGenerator
    {
        string GenerateCode(IProgressReporter pGenerateProgress);
    }
}