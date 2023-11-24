using Smart.Finances.Application.Commands.UserEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Core.Services;
using Smart.Finances.Core.Utils.MessageError;

namespace Smart.Finances.Application.Commands.UserEvent.Handlers
{
    public class EditarUsuarioSenhaHandler : IRequestHandler<UpdatePasswordCommand, UserViewModel>
    {
        private readonly IUpdateRepository<User> _repositoryUpdate;
        private readonly IGetByIdRepository<User> _getByIdRepository;
        private readonly IPasswordService _authService;

        public EditarUsuarioSenhaHandler(IGetByIdRepository<User> obterIdRepository, IUpdateRepository<User> repositoryUpdate, IPasswordService authService)
        {
            _getByIdRepository = obterIdRepository;
            _repositoryUpdate = repositoryUpdate;
            _authService = authService;
        }

        public async Task<UserViewModel> Handle(UpdatePasswordCommand request)
        {
            var user = await _getByIdRepository.GetByIdAsync(request.Id);

            if (user is null)
                throw new Exception(MessageError.UserNotFound);

            user.UpdatePassword(_authService.ComputeSha256Hash(request.Password!));

            var entity = _repositoryUpdate.Update(user);

            return UserViewModel.FromEntity(entity);
        }
    }
}
