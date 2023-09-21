using AutoMapper;

namespace Courses.Services.Order.Application.Mapping
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> layz = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => layz.Value;
    }
}
