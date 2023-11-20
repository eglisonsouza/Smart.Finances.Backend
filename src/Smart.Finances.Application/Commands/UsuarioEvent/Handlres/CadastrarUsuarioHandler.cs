using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Core.Services;
using Smart.Finances.Application.Commands.UsuarioEvent.Commands;
using Smart.Finances.Application.ViewModels;

namespace Smart.Finances.Application.Commands.UsuarioEvent.Handlres
{
    public class CadastrarUsuarioHandler : IRequestHandler<CadastrarUsuarioCommand, UsuarioViewModel>
    {
        private readonly IAddRepository<Usuario> _repository;
        private readonly IAuthService _authService;

        public CadastrarUsuarioHandler(IAddRepository<Usuario> repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<UsuarioViewModel> Handle(CadastrarUsuarioCommand request)
        {
            request.SetSenhaHash(_authService.ComputarSha256Hash(request.Senha));

            var entity =await _repository.AdicionarAsync(request.ToEntity());

            return UsuarioViewModel.FromEntity(entity);
        }
    }
}
