using Microsoft.Extensions.DependencyInjection;

namespace Coworking.Extentions
{
    public static class BaseServiceOptionsRegisterExtension
    {

        public static T AddServiceOptions<T>(this IServiceCollection services, IConfiguration config, string configProperty) where T : class, new()
        {
            var mainOptions = config.GetSection(configProperty);
            T options = new T();
            mainOptions.Bind(options);
            services.AddSingleton<T>(options);
            return options;
        }

        public static T AddServiceOptions<T>(this IServiceCollection services, T options) where T : class, new()
        {
            services.AddSingleton(options);
            return options;
        }
    }
}
