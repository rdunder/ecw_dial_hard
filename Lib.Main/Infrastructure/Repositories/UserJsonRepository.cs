

using Lib.Main.Core.Interfaces;
using Lib.Main.Core.Models;

namespace Lib.Main.Infrastructure.Repositories;

internal class UserJsonRepository : IUserRepository
{
    public void Add(UserEntity entity)
    {
        Console.WriteLine("Repository is adding a new user");
        Console.WriteLine($"{entity.FirstName} {entity.LastName} - ID: {entity.Id}");
    }

    public void Delete(UserModel model)
    {
        Console.WriteLine("Repository is Deleting a new user");
        Console.WriteLine($"{model.FirstName} {model.LastName} - ID: {model.Id}");
    }

    public IEnumerable<UserModel> Get()
    {
        Console.WriteLine("Repository is returning a List of users");
        return Enumerable.Empty<UserModel>();
    }

    public UserModel Get(Guid id)
    {
        Console.WriteLine($"Repository is returning user with ID: {id}");
        return new UserModel();
    }

    public void Update(UserModel model)
    {
        Console.WriteLine($"Repository is updating entity with id: {model.Id}");
    }
}
