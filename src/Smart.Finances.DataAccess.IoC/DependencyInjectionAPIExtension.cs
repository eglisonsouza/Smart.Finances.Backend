using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.DataAccess.Infra.Persistence.Configurations;

namespace Smart.Finances.DataAccess.IoC
{
    public static class DependencyInjectionAPIExtension
    {
        public static IServiceCollection AddInfraestructureApi(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<SqlServerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"),
                b => b.MigrationsAssembly(typeof(SqlServerDbContext).Assembly.FullName)));

            return services;
        }
    }
}
