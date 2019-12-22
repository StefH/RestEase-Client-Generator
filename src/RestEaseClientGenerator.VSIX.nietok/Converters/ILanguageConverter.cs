using System.Threading.Tasks;

namespace RestEaseClientCodeGeneratorVSIX.Converters
{
    public interface ILanguageConverter
    {
        Task<string> ConvertAsync(string code);
    }
}