using Smart.Finances.Application.Commands.DespesaEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Model.Args;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Infra.MessageBus.Queues.Publishers;

namespace Smart.Finances.Application.Commands.DespesaEvent.Handlers
{
    public class CadastroDespesaHandler : IRequestHandler<CadastrarDespesaCommand, DespesaViewModel>
    {
        private readonly IAddRepository<Despesa> _despesaRepository;
        private readonly IAddVariosRepository<Parcelas> _parcelaRepository;
        private readonly INotificationQueuePublisher _notificationQueuePublisher;

        public CadastroDespesaHandler(IAddRepository<Despesa> repository, IAddVariosRepository<Parcelas> parcelaRepository, INotificationQueuePublisher notificationQueuePublisher)
        {
            _despesaRepository = repository;
            _parcelaRepository = parcelaRepository;
            _notificationQueuePublisher = notificationQueuePublisher;
        }

        public async Task<DespesaViewModel> Handle(CadastrarDespesaCommand request)
        {
            var entity = await _despesaRepository.AdicionarAsync(request.ToEntity());

            entity.GerarParcelas(request.PrimeiroVencimento);

            await _parcelaRepository.AdicionarVariosAsync(entity.Parcelas);

            SendEmail(request.EmailUsuario, entity.GerarMensagem());

            return DespesaViewModel.FromEntity(entity);
        }

        public void SendEmail(string email, string mensagem)
        {
            Task.Run(() => _notificationQueuePublisher.Publish(new EmailArgs(email, mensagem, "Cadastro de Despesa")));
        }
    }
}
