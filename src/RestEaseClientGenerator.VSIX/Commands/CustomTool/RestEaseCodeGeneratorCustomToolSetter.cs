using System.Diagnostics.CodeAnalysis;
using RestEaseClientGenerator.VSIX.CustomTool;


namespace RestEaseClientGenerator.VSIX.Commands.CustomTool
{
    [ExcludeFromCodeCoverage]
    public class RestEaseCodeGeneratorCustomToolSetter : CustomToolSetter<RestEaseCodeGenerator>
    {
        public const string Name = nameof(RestEaseCodeGeneratorCustomToolSetter);

        protected override int CommandId { get; } = 0x0200;
    }
}