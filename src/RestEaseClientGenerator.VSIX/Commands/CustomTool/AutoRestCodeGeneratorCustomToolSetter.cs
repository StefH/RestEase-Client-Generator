using System.Diagnostics.CodeAnalysis;
using RestEaseClientGenerator.VSIX.CustomTool.AutoRest;

namespace RestEaseClientGenerator.VSIX.Commands.CustomTool
{
    [ExcludeFromCodeCoverage]
    public class AutoRestCodeGeneratorCustomToolSetter
        : CustomToolSetter<AutoRestCodeGenerator>
    {
        public const string Name = nameof(AutoRestCodeGeneratorCustomToolSetter);

        protected override int CommandId { get; } = 0x0200;
    }
}