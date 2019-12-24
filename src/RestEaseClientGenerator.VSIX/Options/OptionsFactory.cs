using System.Diagnostics.CodeAnalysis;

namespace RestEaseClientGenerator.VSIX.Options
{
    [ExcludeFromCodeCoverage]
    public class OptionsFactory : IOptionsFactory
    {
        public TOptions Create<TOptions, TDialogPage>()
            where TOptions : class
            => VsPackage.Instance.GetDialogPage(typeof(TDialogPage)) as TOptions;
    }
}
