

using Lib.Main.Core.Interfaces;
using Lib.Main.Core.Models;
using Lib.Main.Services.Factories;
using System.Reflection;
using System.Text.Json;

namespace Lib.Main.Infrastructure.Repositories;

public class UserJsonRepository : IUserRepository
{
    private readonly UserFactory _userFactory;

    private readonly string _fileName = "Database.json";
    private readonly string _subFolder = "DialHard";
    private readonly string _basePath;
    private readonly string _connectionString;

    private List<UserEntity> _users;

    public UserJsonRepository()
    {
        _users = new List<UserEntity>();

        _basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), _subFolder);
        if (!Directory.Exists(_basePath))
        {
            Directory.CreateDirectory(_basePath);
        }

        _connectionString = Path.Combine(_basePath, _fileName);
        if (!File.Exists(_connectionString))
        {
            File.WriteAllText(_connectionString, "[]");
        }

        _userFactory = new UserFactory();
        UpdateLocalListOfUsers();
    }

    public bool Add(UserEntity entity)
    {
        UpdateLocalListOfUsers();
        _users.Add(entity);

        try
        {
            string json = JsonSerializer.Serialize(_users);
            File.WriteAllText(_connectionString, json);
            return true;
        }
        catch
        {
            return false;
        }        
    }

    public bool Delete(UserModel model)
    {
        return true;
    }

    public IEnumerable<UserModel> Get()
    {
        List<UserModel> usersReturn = new List<UserModel>();

        UpdateLocalListOfUsers();
       
        foreach (UserEntity entity in _users)
        {
            usersReturn.Add(_userFactory.Create(entity));
        }


        return usersReturn;
    }

    public UserModel Get(Guid id)
    {
        return new UserModel();
    }

    public bool Update(UserModel model)
    {
        return true;
    }

    private void UpdateLocalListOfUsers()
    {
        string rawData = File.ReadAllText(_connectionString);
        try
        {
            _users = JsonSerializer.Deserialize<List<UserEntity>>(rawData)!;
        }
        catch
        {
            _users = new List<UserEntity>();
        }        
    }
}
