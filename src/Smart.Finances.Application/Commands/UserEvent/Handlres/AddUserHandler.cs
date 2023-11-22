﻿using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Core.Services;
using Smart.Finances.Application.Commands.UserEvent.Commands;
using Smart.Finances.Application.ViewModels;

namespace Smart.Finances.Application.Commands.UserEvent.Handlres
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, UserViewModel>
    {
        private readonly IAddRepository<User> _repository;
        private readonly IAuthService _authService;

        public AddUserHandler(IAddRepository<User> repository, IAuthService authService)
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
