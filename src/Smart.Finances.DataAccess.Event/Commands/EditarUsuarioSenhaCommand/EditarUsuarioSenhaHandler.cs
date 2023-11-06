using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Entity;
using Smart.Finances.DataAccess.Core.Repositories.Base;
using Smart.Finances.DataAccess.Core.Services;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Commands.EditarUsuarioSenhaCommand
{
    public class EditarUsuarioSenhaHandler : IRequestHandler<EditarUsuarioSenhaCommand, UsuarioViewModel>
    {
        private readonly IAtualizaRepository<Usuario> _repositoryUpdate;
        private readonly IObterPorIdRepository<Usuario> _obterIdRepository;
        private readonly IAuthService _authService;

        public EditarUsuarioSenhaHandler(IObterPorIdRepository<Usuario> obterIdRepository, IAtualizaRepository<Usuario> repositoryUpdate, IAuthService authService)
        {
            _obterIdRepository = obterIdRepository;
            _repositoryUpdate = repositoryUpdate;
            _authService = authService;
        }

        public Task<UsuarioViewModel> Handle(EditarUsuarioSenhaCommand request)
        {
            var usuario = _obterIdRepository.ObterPorId(request.Id);

            usuario.AtualizarSenha(_authService.ComputarSha256Hash(request.Senha));

            var entity = _repositoryUpdate.Atualizar(usuario);

            return Task.FromResult(UsuarioViewModel.FromEntity(entity));
        }
    }
}
