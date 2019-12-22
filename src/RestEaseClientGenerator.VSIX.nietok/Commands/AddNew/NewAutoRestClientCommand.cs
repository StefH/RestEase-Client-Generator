using System.Diagnostics.CodeAnalysis;

namespace RestEaseClientCodeGeneratorVSIX.Commands.AddNew
{
    [ExcludeFromCodeCoverage]
    public class NewAutoRestClientCommand : NewRestClientCommand
    {
        protected override int CommandId { get; } = 0x0200;

        protected override SupportedCodeGenerator CodeGenerator { get; } = SupportedCodeGenerator.RestEase;
    }
}