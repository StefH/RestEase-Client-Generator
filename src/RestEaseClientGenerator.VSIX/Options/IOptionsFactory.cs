using RestEaseClientGenerator.VSIX.Options.RestEase;

namespace RestEaseClientGenerator.VSIX.Options
{
    public interface IOptionsFactory
    {
        IRestEaseOptions Create<TDialogPage>();

        RestEaseUserOptions Deserialize(string value);

        string Serialize(IRestEaseOptions options);
    }
}