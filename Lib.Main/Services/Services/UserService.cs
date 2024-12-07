﻿

using Lib.Main.Core.Interfaces;
using Lib.Main.Core.Models;
using Lib.Main.Services.Factories;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Lib.Main.Services.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserFactory _userFactory;

    private readonly IFormValidationService _formValidationService;

    public IEnumerable<UserModel> UserList { get; private set; }


    public UserService(IUserRepository userRepository, IUserFactory userFactory)
    {
        _userRepository = userRepository;
        _userFactory = userFactory;

        _formValidationService = new FormValidationService();
        UserList = _userRepository.Get();
    }



    public IEnumerable<ValidationResult> AddUser(UserFormModel formModel)
    {
        var validations = _formValidationService.Validate(formModel);
        if (validations == null)
        {
            var userEntity = _userFactory.Create(formModel);
            _userRepository.Add(userEntity);
            return null!;
        }
        return validations;
    }
    public UserFormModel GetUserFormModel()
    {
        return _userFactory.Create();
    }

    public IEnumerable<UserModel> Get()
    {
        UserList = _userRepository.Get();
        return UserList;
    }
    public UserModel Get(Guid id)
    {
        return _userRepository.Get(id);
    }

    public void UpdateUser()
    {

    }

    public void DeleteUser()
    {

    }
}
