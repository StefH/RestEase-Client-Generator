namespace RestEaseClientCodeGeneratorVSIX.Options
{
    public interface IOptionsFactory
    {
        TOptions Create<TOptions, TDialogPage>()
            where TOptions : class;
    }
}