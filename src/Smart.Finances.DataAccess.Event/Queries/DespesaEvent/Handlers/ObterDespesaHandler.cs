﻿using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Repositories;
using Smart.Finances.Event.Queries.DespesaEvent.Queries;
using Smart.Finances.Event.ViewModels;

namespace Smart.Finances.Event.Queries.DespesaEvent.Handlers
{
    public class ObterDespesaHandler : IRequestHandler<ObterDespesaQuery, List<DespesaViewModel>>
    {
        private readonly IDespesaRepository _repository;

        public ObterDespesaHandler(IDespesaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DespesaViewModel>> Handle(ObterDespesaQuery request)
        {
            var despesas = await _repository.ObterDespesaPorMesAsync(request.MesReferencia, request.UsuarioId);

            return DespesaViewModel.FromEntity(despesas);
        }
    }
}
