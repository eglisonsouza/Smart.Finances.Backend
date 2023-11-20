using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Application.Commands.UsuarioEvent.Commands;
using Smart.Finances.Application.ViewModels;

namespace Smart.Finances.Application.Commands.UsuarioEvent.Handlres
{
    public class EditarUsuarioHandler : IRequestHandler<EditarUsuarioCommand, UsuarioViewModel>
    {
        private readonly IAtualizaRepository<Usuario> _repositoryUpdate;
        private readonly IObterPorIdRepository<Usuario> _obterIdRepository;

        public EditarUsuarioHandler(IAtualizaRepository<Usuario> repositoryUpdate, IObterPorIdRepository<Usuario> obterIdRepository)
        {
            _repositoryUpdate = repositoryUpdate;
            _obterIdRepository = obterIdRepository;
        }

        public async Task<UsuarioViewModel> Handle(EditarUsuarioCommand request)
        {
            var usuario = await _obterIdRepository.ObterPorIdAsync(request.Id);

            usuario.AtualizarPerfil(request.NomeCompleto, request.Email);

            var entity = await _repositoryUpdate.AtualizarAsync(usuario);

            return UsuarioViewModel.FromEntity(entity);
        }
    }
}
