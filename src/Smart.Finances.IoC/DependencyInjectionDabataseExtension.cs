﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.Infra.Persistence.Configurations;

namespace Smart.Finances.IoC
{
    public static class DependencyInjectionDabataseExtension
    {
        public static IServiceCollection AddContextSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerDbContext>(options => 
                options.UseSqlServer(configuration.GetSection("Settings").GetConnectionString("SqlServerConnection"),
                b => b.MigrationsAssembly(typeof(SqlServerDbContext).Assembly.FullName)));

            return services;
        }
    }
}
