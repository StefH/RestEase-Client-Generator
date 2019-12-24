namespace RestEaseClientGenerator.VSIX.Options
{
    public interface IOptionsFactory
    {
        TOptions Create<TOptions, TDialogPage>() where TOptions : class;
    }
}