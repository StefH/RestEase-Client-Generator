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
            // https://github.com/AutoMapper/AutoMapper/issues/3304 ???
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RestEaseUserOptions, RestEaseOptionsPage>();
                //.ForAllMembers(opt => opt.Condition((src, dest, srcVal) =>
                //{
                //    return srcVal != null;
                //}));

                cfg.CreateMap<IRestEaseOptions, GeneratorSettings>();
                //.ForAllMembers(opt => opt.Condition((src, dest, srcVal) => srcVal != null));

                cfg.CreateMap<int?, int>().ConvertUsing((sourceValue, destinationValue) => sourceValue ?? destinationValue);
                cfg.CreateMap<bool?, bool>().ConvertUsing((sourceValue, destinationValue) => sourceValue ?? destinationValue);
                cfg.CreateMap<string, string>().ConvertUsing((sourceValue, destinationValue) => !string.IsNullOrEmpty(sourceValue) ? sourceValue : destinationValue);
            });

            config.AssertConfigurationIsValid();

            Mapper = new Mapper(config);
        }
    }
}