using System.Diagnostics.CodeAnalysis;

namespace RestEaseClientGenerator.VSIX.Commands.AddNew
{
    [ExcludeFromCodeCoverage]
    public class NewRestEaseClientCommand : NewRestClientCommand
    {
        protected override int CommandId { get; } = 0x0200;

        protected override SupportedCodeGenerator CodeGenerator { get; } = SupportedCodeGenerator.RestEase;
    }
}