using Smart.Finances.Application.Commands.UserEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Core.Services;

namespace Smart.Finances.Application.Commands.UserEvent.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, UserViewModel>
    {
        private readonly IAddRepository<User> _repository;
        private readonly IPasswordService _authService;

        public AddUserHandler(IAddRepository<User> repository, IPasswordService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<UserViewModel> Handle(AddUserCommand request)
        {
            request.SetSenhaHash(_authService.ComputeSha256Hash(request.Password!));

            var entity = await _repository.AddAsync(request.ToEntity());

            return UserViewModel.FromEntity(entity);
        }
    }
}
