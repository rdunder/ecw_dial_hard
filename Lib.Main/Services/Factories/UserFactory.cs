

using Lib.Main.Core.Interfaces;
using Lib.Main.Core.Models;

namespace Lib.Main.Services.Factories;

internal class UserFactory : IFactory<UserFormModel, UserEntity, UserModel>
{
    public UserFormModel Create()
    {
        return new UserFormModel();
    }

    public UserEntity Create(UserFormModel formModel)
    {
        return new UserEntity
        {
            Id = Guid.NewGuid(),
            FirstName = formModel.FirstName,
            LastName = formModel.LastName,
            Email = formModel.Email,
            PhoneNumber = formModel.PhoneNumber,
            Adress = formModel.Adress,
            PostalCode = formModel.PostalCode,
            County = formModel.County,

            EmailConfirmed = false
        };
    }

    public UserModel Create(UserEntity entity)
    {
        return new UserModel
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            Adress = entity.Adress,
            PostalCode = entity.PostalCode,
            County = entity.County,
        };
    }
}
