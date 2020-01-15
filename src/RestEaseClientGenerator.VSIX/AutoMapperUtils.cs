using AutoMapper;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.VSIX.Options.RestEase;

namespace RestEaseClientGenerator.VSIX
{
    public sealed class AutoMapperUtils
    {
        public Mapper Mapper { get; }

        public static AutoMapperUtils Instance { get; } = new AutoMapperUtils();

        private AutoMapperUtils()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RestEaseUserOptions, RestEaseOptionsPage>();
                cfg.CreateMap<IRestEaseOptions, GeneratorSettings>();
            });

            Mapper = new Mapper(config);
        }
    }
}