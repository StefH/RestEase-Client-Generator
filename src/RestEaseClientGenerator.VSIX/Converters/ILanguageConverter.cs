using System.Threading.Tasks;

namespace RestEaseClientGenerator.VSIX.Converters
{
    public interface ILanguageConverter
    {
        Task<string> ConvertAsync(string code);
    }
}