using Nelibur.ObjectMapper;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGenerator.Utils;

internal sealed class TinyMapperUtils
{
    public static TinyMapperUtils Instance { get; } = new();

    private TinyMapperUtils()
    {
        TinyMapper.Bind<GeneratorSettings, GeneratorSettings>();
    }

    public void Map<TSource, TTarget>(TSource source, TTarget target)
    {
        TinyMapper.Map(source, target);
    }

    public TTarget Map<TTarget>(object source)
    {
        return TinyMapper.Map<TTarget>(source);
    }
}