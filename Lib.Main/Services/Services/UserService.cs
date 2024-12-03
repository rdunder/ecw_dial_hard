

using Lib.Main.Core.Interfaces;
using Lib.Main.Core.Models;
using Lib.Main.Services.Factories;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Lib.Main.Services.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserFactory _userFactory;
    private readonly FormValidationService _formValidationService;   

    public IEnumerable<UserModel> userList;


    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _userFactory = new UserFactory();
        _formValidationService = new FormValidationService();
        userList = _userRepository.Get();
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
        userList = _userRepository.Get();
        return userList;
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
