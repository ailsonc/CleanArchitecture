using AutoMapper;
using CleanArchitecture.Application.AutoMapper.Mappers;

namespace CleanArchitecture.Application.AutoMapper
{
    public class ConfigAutoMapper
    {
        public ConfigAutoMapper()
        {
        }

        public static MapperConfiguration AutoMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CategoryMapper());
                cfg.AddProfile(new ProductMapper());
            });
            return config;
        }
    }
}
