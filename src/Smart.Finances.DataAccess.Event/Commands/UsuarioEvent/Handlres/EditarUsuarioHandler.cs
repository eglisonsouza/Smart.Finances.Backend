﻿using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Entity;
using Smart.Finances.DataAccess.Core.Repositories.Base;
using Smart.Finances.DataAccess.Event.Commands.UsuarioEvent.Commands;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Commands.UsuarioEvent.Handlres
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
