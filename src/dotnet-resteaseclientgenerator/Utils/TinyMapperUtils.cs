using Nelibur.ObjectMapper;

namespace DotNetRestEaseClientGenerator.Utils;

internal sealed class TinyMapperUtils
{
    public static TinyMapperUtils Instance { get; } = new();

    private TinyMapperUtils()
    {
        TinyMapper.Bind<Program.Options, GeneratorSettings>(config =>
        {
            // config.Ignore(x => x.?);
        });
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