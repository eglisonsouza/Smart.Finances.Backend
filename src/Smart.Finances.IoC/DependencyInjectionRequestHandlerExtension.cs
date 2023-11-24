using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.Application.Commands.CategoryEvent.Commands;
using Smart.Finances.Application.Commands.CategoryEvent.Handlers;
using Smart.Finances.Application.Commands.ExpenseEvent.Commands;
using Smart.Finances.Application.Commands.ExpenseEvent.Handlers;
using Smart.Finances.Application.Commands.InstallmentEvent.Commands;
using Smart.Finances.Application.Commands.InstallmentEvent.Handlers;
using Smart.Finances.Application.Commands.UserEvent.Commands;
using Smart.Finances.Application.Commands.UserEvent.Handlers;
using Smart.Finances.Application.Queries.CategoryEvent.Handlers;
using Smart.Finances.Application.Queries.CategoryEvent.Queries;
using Smart.Finances.Application.Queries.ExpenseEvent.Handlers;
using Smart.Finances.Application.Queries.ExpenseEvent.Queries;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;

namespace Smart.Finances.IoC
{
    public static class DependencyInjectionRequestHandlerExtension
    {
        public static IServiceCollection AddRequestHandler(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AddCategoryCommand, CategoryViewModel>, AddCategoryHandler>();
            services.AddScoped<IRequestHandler<EditCategoryCommand, CategoryViewModel>, UpdateCategoryHandler>();
            services.AddScoped<IRequestHandler<GetAllCategoryQuery, List<CategoryViewModel>>, GetAllCategoryHandler>();
            services.AddScoped<IRequestHandler<AddUserCommand, UserViewModel>, AddUserHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, UserViewModel>, UpdateUserHandler>();
            services.AddScoped<IRequestHandler<UpdatePasswordCommand, UserViewModel>, EditarUsuarioSenhaHandler>();
            services.AddScoped<IRequestHandler<AddExpenseCommand, ExpenseViewModel>, AddExpenseHandler>();
            services.AddScoped<IRequestHandler<InactivateExpenseCommand, ExpenseViewModel>, InativateExpenseHandler>();
            services.AddScoped<IRequestHandler<PayInstallmentCommand, InstallmentViewModel>, PayInstallmentHandler>();
            services.AddScoped<IRequestHandler<GetExpenseQuery, List<ExpenseViewModel>>, GetExpenseHandler>();
            services.AddScoped<IRequestHandler<GetExpenseMontheyQuery, List<ExpenseViewModel>>, GetExpenseMontheyHandler>();
            services.AddScoped<IRequestHandler<LoginCommand, LoginViewModel>, LoginHandler>();

            return services;
        }
    }
}
