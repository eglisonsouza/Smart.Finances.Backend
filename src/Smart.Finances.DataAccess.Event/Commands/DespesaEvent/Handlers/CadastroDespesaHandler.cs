using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Entity;
using Smart.Finances.DataAccess.Core.Repositories.Base;
using Smart.Finances.DataAccess.Event.Commands.DespesaEvent.Commands;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Commands.DespesaEvent.Handlers
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

        public Task<DespesaViewModel> Handle(CadastrarDespesaCommand request)
        {
            var entity = _despesaRepository.Adicionar(request.ToEntity());

            entity.GerarParcelas(request.PrimeiroVencimento);

            _parcelaRepository.AdicionarVarios(entity.Parcelas);

            return Task.FromResult(DespesaViewModel.FromEntity(entity));
        }
    }
}
