using Smart.Finances.Application.Commands.UserEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Core.Utils.MessageError;

namespace Smart.Finances.Application.Commands.UserEvent.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserViewModel>
    {
        private readonly IUpdateRepository<User> _updateRepository;
        private readonly IGetByIdRepository<User> _getByIdRepository;

        public UpdateUserHandler(IUpdateRepository<User> updateRepository, IGetByIdRepository<User> getByIdRepository)
        {
            _updateRepository = updateRepository;
            _getByIdRepository = getByIdRepository;
        }

        public async Task<UserViewModel> Handle(UpdateUserCommand request)
        {
            var user = await UpdateProfile(request);

            var entity = _updateRepository.Update(user);

            return UserViewModel.FromEntity(entity);
        }

        private async Task<User> UpdateProfile(UpdateUserCommand request)
        {
            var user = await _getByIdRepository.GetByIdAsync(request.Id);

            if(user is null)
                throw new Exception(MessageError.UserNotFound);

            user.UpdateProfile(request.Name!, request.Email!);

            return user;
        }
    }
}
