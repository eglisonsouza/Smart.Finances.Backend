using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Event.Commands;
using Smart.Finances.DataAccess.Event.ViewModels;
using Smart.Finances.DataAccess.Infra.MessageBus.Queues.Consumers;
using Smart.Finances.DataAccess.Infra.MessageBus.Queues.Publishers;
using Smart.Finances.DataAccess.Infra.MessageBus.Setup;
using Smart.Finances.DataAccess.Infra.Persistence.Configurations;

namespace Smart.Finances.DataAccess.IoC
{
    public static class DependencyInjectionAPIExtension
    {
        public static IServiceCollection AddInfraestructureApi(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("SqlServerConnection");

            services.AddScoped<IRequestHandler<AdicionarCategoriaCommand, CategoriaViewModel>, AdicionarCategoriaHandler>();


            services.AddDbContext<SqlServerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"),
                b => b.MigrationsAssembly(typeof(SqlServerDbContext).Assembly.FullName)));

            services.AddSingleton<IDespesaQueueConsumer, DespesaQueueConsumer>();
            services.AddSingleton<IDespesaQueuePublisher, DespesaQueuePublisher>();


            services.AddHostedService<RabbitMqConsumerSetup<IDespesaQueueConsumer>>();
            return services;
        }
    }
}
