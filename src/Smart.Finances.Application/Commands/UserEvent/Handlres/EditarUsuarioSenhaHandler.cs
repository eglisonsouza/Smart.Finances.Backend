using Smart.Finances.Application.Commands.UserEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Core.Services;

namespace Smart.Finances.Application.Commands.UserEvent.Handlres
{
    public class EditarUsuarioSenhaHandler : IRequestHandler<UpdatePasswordCommand, UserViewModel>
    {
        private readonly IUpdateRepository<User> _repositoryUpdate;
        private readonly IGetByIdRepository<User> _getByIdRepository;
        private readonly IAuthService _authService;

        public EditarUsuarioSenhaHandler(IGetByIdRepository<User> obterIdRepository, IUpdateRepository<User> repositoryUpdate, IAuthService authService)
        {
            _getByIdRepository = obterIdRepository;
            _repositoryUpdate = repositoryUpdate;
            _authService = authService;
        }

        public async Task<UserViewModel> Handle(UpdatePasswordCommand request)
        {
            var user = await _getByIdRepository.GetByIdAsync(request.Id);

            user.UpdatePassword(_authService.ComputeSha256Hash(request.Password!));

            var entity = _repositoryUpdate.Update(user);

            return UserViewModel.FromEntity(entity);
        }
    }
}
