using Lib.Main.Core.Interfaces;
using Lib.Main.Core.Models;
using Lib.Main.Infrastructure.Repositories;
using Moq;

namespace Lib.Main.Tests;

public class UserRepositoryTests
{
    private readonly IUserRepository _sut = new UserJsonRepository("dummy_connection_string");

    [Fact]
    public void UserJsonRepository_Add_ShouldReturnTrue()
    {
        //  Arrange
        var fakeEntity = new UserEntity();

        //  Act
        _sut.Add(fakeEntity);

        //  Assert
    }

    [Fact]
    public void UserJsonRepository_Add_ShouldReturnFalse()
    {
        //  Arrange

        //  Act

        //  Assert
    }

    [Fact]
    public void UserJsonRepository_Delete_ShouldReturnTrue()
    {
        //  Arrange

        //  Act

        //  Assert
    }

    [Fact]
    public void UserJsonRepository_Delete_ShouldReturnFalse()
    {
        //  Arrange

        //  Act

        //  Assert
    }

    [Fact]
    public void UserJsonRepository_Get_ShouldReturnUserList()
    {
        //  Arrange

        //  Act

        //  Assert
    }

    [Fact]
    public void UserJsonRepository_Get_ShouldReturnOneUser()
    {
        //  Arrange

        //  Act

        //  Assert
    }

    [Fact]
    public void UserJsonRepository_Update_ShouldReturnTrue()
    {
        //  Arrange

        //  Act

        //  Assert
    }

    [Fact]
    public void UserJsonRepository_Update_ShouldReturnFalse()
    {
        //  Arrange

        //  Act

        //  Assert
    }
}
