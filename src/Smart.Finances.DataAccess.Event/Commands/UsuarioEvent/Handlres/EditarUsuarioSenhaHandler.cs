using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Entity;
using Smart.Finances.DataAccess.Core.Repositories.Base;
using Smart.Finances.DataAccess.Core.Services;
using Smart.Finances.DataAccess.Event.Commands.UsuarioEvent.Commands;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Commands.UsuarioEvent.Handlres
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

        public async Task<UsuarioViewModel> Handle(EditarUsuarioSenhaCommand request)
        {
            var usuario = await _obterIdRepository.ObterPorIdAsync(request.Id);

            usuario.AtualizarSenha(_authService.ComputarSha256Hash(request.Senha));

            var entity = await _repositoryUpdate.AtualizarAsync(usuario);

            return UsuarioViewModel.FromEntity(entity);
        }
    }
}
