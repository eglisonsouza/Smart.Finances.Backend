using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.Core.Repositories;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Infra.Persistence.Configurations;
using Smart.Finances.Infra.Persistence.Repositories;

namespace Smart.Finances.IoC
{
    public static class DependencyInjectionRepositoriesExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAddRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUpdateRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGetByIdRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGetAllRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAddAllRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
