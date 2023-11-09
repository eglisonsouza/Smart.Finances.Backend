using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Event.Commands.CategoriaEvent.Commands;
using Smart.Finances.DataAccess.Event.Commands.CategoriaEvent.Handlers;
using Smart.Finances.DataAccess.Event.Commands.DespesaEvent.Commands;
using Smart.Finances.DataAccess.Event.Commands.DespesaEvent.Handlers;
using Smart.Finances.DataAccess.Event.Commands.ParcelaEvent.Commands;
using Smart.Finances.DataAccess.Event.Commands.ParcelaEvent.Handlers;
using Smart.Finances.DataAccess.Event.Commands.UsuarioEvent.Commands;
using Smart.Finances.DataAccess.Event.Commands.UsuarioEvent.Handlres;
using Smart.Finances.DataAccess.Event.Queries.CategoriaEvent.Handlers;
using Smart.Finances.DataAccess.Event.Queries.CategoriaEvent.Queries;
using Smart.Finances.DataAccess.Event.Queries.DespesaEvent.Handlers;
using Smart.Finances.DataAccess.Event.Queries.DespesaEvent.Queries;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.IoC
{
    public static class DependencyInjectionRequestHandlerExtension
    {
        public static IServiceCollection AddRequestHandler(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarCategoriaCommand, CategoriaViewModel>, AdicionarCategoriaHandler>();
            services.AddScoped<IRequestHandler<EditarCategoriaCommand, CategoriaViewModel>, EditarCategoriaHandler>();
            services.AddScoped<IRequestHandler<ObterTodasCategociaQuery, List<CategoriaViewModel>>, ObterTodasCategociaHandler>();
            services.AddScoped<IRequestHandler<CadastrarUsuarioCommand, UsuarioViewModel>, CadastrarUsuarioHandler>();
            services.AddScoped<IRequestHandler<EditarUsuarioCommand, UsuarioViewModel>, EditarUsuarioHandler>();
            services.AddScoped<IRequestHandler<EditarUsuarioSenhaCommand, UsuarioViewModel>, EditarUsuarioSenhaHandler>();
            services.AddScoped<IRequestHandler<CadastrarDespesaCommand, DespesaViewModel>, CadastroDespesaHandler>();
            services.AddScoped<IRequestHandler<InativarDespesaCommand, DespesaViewModel>, InativarDespesaHandler>();
            services.AddScoped<IRequestHandler<PagarParcelaCommand, ParcelasViewModel>, PagarParcelaHandler>();
            services.AddScoped<IRequestHandler<ObterDespesaQuery, List<DespesaViewModel>>, ObterDespesaHandler>();
            services.AddScoped<IRequestHandler<ObterDespesaRecorrenteQuery, List<DespesaViewModel>>, ObterDespesaRecorrenteHandler>();

            return services;
        }
    }
}
