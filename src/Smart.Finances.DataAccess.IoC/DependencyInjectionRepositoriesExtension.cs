using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.Core.Repositories;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Infra.Persistence.Repositories;

namespace Smart.Finances.IoC
{
    public static class DependencyInjectionRepositoriesExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAddRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAtualizaRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IObterPorIdRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IObterTodosRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAddVariosRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IDespesaRepository, DespesaRepository>();

            return services;
        }
    }
}
