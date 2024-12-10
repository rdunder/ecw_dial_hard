

using Lib.Main.Core.Interfaces;
using Lib.Main.Core.Models;
using Lib.Main.Infrastructure.Repositories;
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

    public IEnumerable<ValidationResult> UpdateUser(UserModel model, UserFormModel formModel)
    {
        var validations = _formValidationService.Validate(formModel);
        if (validations == null || !validations.Any())
        {
            var userEntity = _userFactory.Create(formModel);
            _userRepository.Add(userEntity);
            _userRepository.Delete(model);
            return null!;
        }

        return validations;
    }

    public void DeleteUser(UserModel userModel)
    {
        _userRepository.Delete(userModel);
    }
}
