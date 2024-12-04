using Lib.Main.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Lib.Main.Core.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserModel> UserList { get; }

        IEnumerable<ValidationResult> AddUser(UserFormModel formModel);
        void DeleteUser();
        IEnumerable<UserModel> Get();
        UserModel Get(Guid id);
        UserFormModel GetUserFormModel();
        void UpdateUser();
    }
}