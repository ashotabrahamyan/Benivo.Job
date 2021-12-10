using AutoMapper;

namespace BenivoJob.WebApi.Configuration
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<Domain.Entities.Job, Infrastructure.Persistence.Entities.Job>();
                 
            });
            return configuration;
        }
    }
}
