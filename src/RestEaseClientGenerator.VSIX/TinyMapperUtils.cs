using Nelibur.ObjectMapper;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.VSIX.Options.RestEase;

namespace RestEaseClientGenerator.VSIX
{
    internal sealed class TinyMapperUtils
    {
        public static TinyMapperUtils Instance { get; } = new TinyMapperUtils();

        private TinyMapperUtils()
        {
            TinyMapper.Bind<RestEaseUserOptions, RestEaseOptionsPage>(config =>
            {
                // config.Ignore(x => x.?);
            });

            TinyMapper.Bind<IRestEaseOptions, GeneratorSettings>(config =>
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
}