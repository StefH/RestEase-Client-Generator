using System.Linq;
using Nelibur.ObjectMapper;
using RestEaseClientGenerator.Settings;

namespace DotNetRestEaseClientGenerator.Utils;

internal sealed class TinyMapperUtils
{
    public static TinyMapperUtils Instance { get; } = new();

    private TinyMapperUtils()
    {
        TinyMapper.Bind<Program.Options, GeneratorSettings>(config =>
        {
            config.Ignore(x => x.ConstantQueryParameters);
        });
    }

    public GeneratorSettings Map(Program.Options options)
    {
        var settings = TinyMapper.Map<GeneratorSettings>(options);

        if (options.ConstantQueryParameters != null)
        {
            settings.ConstantQueryParameters = DictionaryUtils.ToDictionary(options.ConstantQueryParameters);
        }

        return settings;
    }
}