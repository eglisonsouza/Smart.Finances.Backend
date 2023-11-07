using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Entity;
using Smart.Finances.DataAccess.Core.Repositories.Base;
using Smart.Finances.DataAccess.Core.Services;
using Smart.Finances.DataAccess.Event.Commands.UsuarioEvent.Commands;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Commands.UsuarioEvent.Handlres
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

        public Task<UsuarioViewModel> Handle(CadastrarUsuarioCommand request)
        {
            request.SetSenhaHash(_authService.ComputarSha256Hash(request.Senha));

            var entity = _repository.Adicionar(request.ToEntity());

            return Task.FromResult(UsuarioViewModel.FromEntity(entity)); ;
        }
    }
}
