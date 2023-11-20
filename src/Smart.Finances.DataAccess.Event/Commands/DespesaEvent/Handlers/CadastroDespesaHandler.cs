﻿using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Event.Commands.DespesaEvent.Commands;
using Smart.Finances.Event.ViewModels;

namespace Smart.Finances.Event.Commands.DespesaEvent.Handlers
{
    public class CadastroDespesaHandler : IRequestHandler<CadastrarDespesaCommand, DespesaViewModel>
    {
        private readonly IAddRepository<Despesa> _despesaRepository;
        private readonly IAddVariosRepository<Parcelas> _parcelaRepository;


        public CadastroDespesaHandler(IAddRepository<Despesa> repository, IAddVariosRepository<Parcelas> parcelaRepository)
        {
            _despesaRepository = repository;
            _parcelaRepository = parcelaRepository;
        }

        public async Task<DespesaViewModel> Handle(CadastrarDespesaCommand request)
        {
            var entity = await _despesaRepository.AdicionarAsync(request.ToEntity());

            entity.GerarParcelas(request.PrimeiroVencimento);

            await _parcelaRepository.AdicionarVariosAsync(entity.Parcelas);

            return DespesaViewModel.FromEntity(entity);
        }
    }
}