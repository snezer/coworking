using Coworking.Core.DA.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Core.DA.Extentions
{
    public static class DBContextExtentions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationRoot config)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.ConfigureOptions<DatabaseOptionsConfiguration>();
            services.AddDbContext<CoworkingDbContext>(ServiceLifetime.Scoped);
            return services;
        }
    }
}
