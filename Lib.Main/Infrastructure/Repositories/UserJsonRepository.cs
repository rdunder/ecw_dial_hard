

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
        UpdateJsonDatabase();
    }

    public void Add(UserEntity entity)
    {
        UpdateJsonDatabase();
        _users.Add(entity);

        string json = JsonSerializer.Serialize(_users);
        File.WriteAllText(_connectionString, json);
    }

    public void Delete(UserModel model)
    {
    }

    public IEnumerable<UserModel> Get()
    {
        List<UserModel> usersReturn = new List<UserModel>();

        UpdateJsonDatabase();
       
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

    public void Update(UserModel model)
    {
    }

    private void UpdateJsonDatabase()
    {
        string rawData = File.ReadAllText(_connectionString);
        try
        {
            _users = JsonSerializer.Deserialize<List<UserEntity>>(rawData)!;
        }
        catch (Exception ex)
        {
            _users = new List<UserEntity>();
        }        
    }
}
