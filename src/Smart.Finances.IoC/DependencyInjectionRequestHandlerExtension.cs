using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Application.Commands.CategoriaEvent.Commands;
using Smart.Finances.Application.Commands.CategoriaEvent.Handlers;
using Smart.Finances.Application.Commands.DespesaEvent.Commands;
using Smart.Finances.Application.Commands.DespesaEvent.Handlers;
using Smart.Finances.Application.Commands.ParcelaEvent.Commands;
using Smart.Finances.Application.Commands.ParcelaEvent.Handlers;
using Smart.Finances.Application.Commands.UsuarioEvent.Commands;
using Smart.Finances.Application.Commands.UsuarioEvent.Handlres;
using Smart.Finances.Application.Queries.CategoriaEvent.Handlers;
using Smart.Finances.Application.Queries.CategoriaEvent.Queries;
using Smart.Finances.Application.Queries.DespesaEvent.Handlers;
using Smart.Finances.Application.Queries.DespesaEvent.Queries;
using Smart.Finances.Application.ViewModels;

namespace Smart.Finances.IoC
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
