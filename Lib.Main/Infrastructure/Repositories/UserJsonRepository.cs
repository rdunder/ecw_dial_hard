

using Lib.Main.Core.Interfaces;
using Lib.Main.Core.Models;
using Lib.Main.Services.Factories;
using System.Reflection;
using System.Text.Json;

namespace Lib.Main.Infrastructure.Repositories;

public class UserJsonRepository : IUserRepository
{
    private readonly UserFactory _userFactory;
    private readonly string _connectionString;
    private List<UserEntity> _users;

    public UserJsonRepository(string connectionString)
    {
        _userFactory = new UserFactory();
        _connectionString = connectionString;
        _users = new List<UserEntity>();

        var basePath = Path.GetDirectoryName(_connectionString);
        if (!Directory.Exists(basePath) && basePath != null)
        {
            Directory.CreateDirectory(basePath);
        }

        if (!File.Exists(_connectionString))
        {
            File.WriteAllText(_connectionString, "[]");
        }
       
        UpdateLocalListOfUsers();
    }

    public void Add(UserEntity entity)
    {
        UpdateLocalListOfUsers();
        _users.Add(entity);

        UpdateJsonFile();
    }

    public bool Delete(UserModel model)
    {
        UpdateLocalListOfUsers();

        try
        {
            _users.RemoveAll(user => user.Id == model.Id);
            UpdateJsonFile();
            return true;
        }
        catch 
        {
            return false;
        }        
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
        UpdateLocalListOfUsers();
        var entity = _users.FirstOrDefault(x => x.Id == id) ?? new();
        var user = _userFactory.Create( entity );

        return user;
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

    private void UpdateJsonFile()
    {
        try
        {
            string json = JsonSerializer.Serialize(_users);
            File.WriteAllText(_connectionString, json);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
