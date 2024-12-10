using Lib.Main.Core.Interfaces;
using Lib.Main.Core.Models;
using Lib.Main.Services.Services;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace Lib.Main.Tests;

public class UserServiceTests
{

    [Fact]
    public void UserService_AddUser_ShouldReturnNull()
    {
        //  Arrange
        var formValidationServiceMOCK = new Mock<IFormValidationService>();
        var userFactoryMOCK = new Mock<IUserFactory>();
        var userRepositoryMOCK = new Mock<IUserRepository>();
        
        var fakeUserEntityModel = new UserEntity();
        var fakeUserFormModel = new UserFormModel()
        {
            FirstName = "FakeName",
            LastName = "FakeName",
            Email = "fake.email@domain.com",
            PhoneNumber = "1234567890"
        };

        formValidationServiceMOCK
            .Setup(x => x.Validate(fakeUserFormModel))
            .Returns((List<ValidationResult>)null!);

        userFactoryMOCK
            .Setup(x => x.Create(It.IsAny<UserFormModel>()))
            .Returns(fakeUserEntityModel);

        var _sut = new UserService(userRepositoryMOCK.Object, userFactoryMOCK.Object);

        //  Act
        var result = _sut.AddUser(fakeUserFormModel);

        //  Assert
        Assert.Null(result);
        userRepositoryMOCK.Verify(x => x.Add(fakeUserEntityModel), Times.Once);
    }

    [Fact]
    public void UserService_AddUser_ShouldReturnValidationResults()
    {
        //  Arrange
        var formValidationServiceMOCK = new Mock<IFormValidationService>();
        var userFactoryMOCK = new Mock<IUserFactory>();
        var userRepositoryMOCK = new Mock<IUserRepository>();

        var fakeUserEntityModel = new UserEntity();
        var fakeUserFormModel = new UserFormModel();
        var fakeValidationResults = new List<ValidationResult>();

        formValidationServiceMOCK
            .Setup(x => x.Validate(fakeUserFormModel))
            .Returns(fakeValidationResults);

        userFactoryMOCK
            .Setup(x => x.Create(It.IsAny<UserFormModel>()))
            .Returns(fakeUserEntityModel);

        var _sut = new UserService(userRepositoryMOCK.Object, userFactoryMOCK.Object);

        //  Act
        var result = _sut.AddUser(fakeUserFormModel);

        //  Assert
        Assert.NotNull(result);
        userFactoryMOCK.Verify(x => x.Create(fakeUserEntityModel), Times.Never);
        userRepositoryMOCK.Verify(x => x.Add(fakeUserEntityModel), Times.Never);
    }

    [Fact]
    public void UserService_GetUserFormModel_ShouldReturnUserFormModel()
    {
        //  Arrange
        var userFactoryMOCK = new Mock<IUserFactory>();
        var userRepositoryMOCK = new Mock<IUserRepository>();

        userFactoryMOCK
            .Setup(x => x.Create())
            .Returns(new UserFormModel());

        var _sut = new UserService(userRepositoryMOCK.Object, userFactoryMOCK.Object);

        //  Act
        var userFormModel = _sut.GetUserFormModel();

        //  Assert
        Assert.NotNull(userFormModel);
        Assert.IsType<UserFormModel>(userFormModel);
    }

    [Fact]
    public void UserService_Get_ShouldReturnAllUsers()
    {
        //  Arrange
        var userFactoryMOCK = new Mock<IUserFactory>();
        var userRepositoryMOCK = new Mock<IUserRepository>();

        IEnumerable<UserModel> fakeUsers = new List<UserModel>();

        userRepositoryMOCK
            .Setup(x => x.Get())
            .Returns(fakeUsers);

        var _sut = new UserService(userRepositoryMOCK.Object, userFactoryMOCK.Object);

        //  Act
        var result = _sut.Get();

        //  Assert
        Assert.NotNull(result);
        Assert.IsType<List<UserModel>>(result);
        userRepositoryMOCK.Verify(x => x.Get(), Times.Between(1, 2, Moq.Range.Inclusive));
    }

    [Fact]
    public void UserService_Get_ShouldReturnOneUsers()
    {
        //  Arrange
        var userFactoryMOCK = new Mock<IUserFactory>();
        var userRepositoryMOCK = new Mock<IUserRepository>();

        UserModel fakeUserModel = new UserModel();
        var fakeGuid = Guid.NewGuid();

        userRepositoryMOCK
            .Setup(x => x.Get(fakeGuid))
            .Returns(fakeUserModel);

        var _sut = new UserService(userRepositoryMOCK.Object, userFactoryMOCK.Object);

        //  Act
        var result = _sut.Get(fakeGuid);

        //  Assert
        Assert.NotNull(result);
        Assert.IsType<UserModel>(result);
        userRepositoryMOCK.Verify(x => x.Get(fakeGuid), Times.Once);
    }

    [Fact]
    public void UserService_UpdateUser_ShouldReturnNull()
    {
        //  Arrange
        var formValidationServiceMOCK = new Mock<IFormValidationService>();
        var userFactoryMOCK = new Mock<IUserFactory>();
        var userRepositoryMOCK = new Mock<IUserRepository>();

        var fakeuserModel = new UserModel();
        var fakeEntityModel = new UserEntity();
        var fakeUserFormModel = new UserFormModel()
        {
            FirstName = "FakeName",
            LastName = "FakeName",
            Email = "fake.email@domain.com",
            PhoneNumber = "1234567890"
        };

        formValidationServiceMOCK
            .Setup(x => x.Validate(fakeUserFormModel))
            .Returns((List<ValidationResult>)null!);

        userFactoryMOCK
            .Setup(x => x.Create(fakeUserFormModel))
            .Returns(fakeEntityModel);

        var _sut = new UserService(userRepositoryMOCK.Object, userFactoryMOCK.Object);

        //  Act
        var result = _sut.UpdateUser(fakeuserModel, fakeUserFormModel);

        //  Assert
        Assert.Null(result);
        userRepositoryMOCK.Verify(x => x.Add(It.IsAny<UserEntity>()), Times.Once);
        userRepositoryMOCK.Verify(x => x.Delete(fakeuserModel), Times.Once);
    }

    [Fact]
    public void UserService_UpdateUser_ShouldReturnValidationResults()
    {
        //  Arrange
        var formValidationServiceMOCK = new Mock<IFormValidationService>();
        var userFactoryMOCK = new Mock<IUserFactory>();
        var userRepositoryMOCK = new Mock<IUserRepository>();

        var fakeUserEntityModel = new UserEntity();
        var fakeUserFormModel = new UserFormModel();
        var fakeUserModel = new UserModel();
        var fakeValidationResults = new List<ValidationResult>();

        formValidationServiceMOCK
            .Setup(x => x.Validate(fakeUserFormModel))
            .Returns(fakeValidationResults);

        userFactoryMOCK
            .Setup(x => x.Create(It.IsAny<UserFormModel>()))
            .Returns(fakeUserEntityModel);

        var _sut = new UserService(userRepositoryMOCK.Object, userFactoryMOCK.Object);

        //  Act
        var result = _sut.UpdateUser(fakeUserModel, fakeUserFormModel);

        //  Assert
        Assert.NotNull(result);
        userFactoryMOCK.Verify(x => x.Create(fakeUserEntityModel), Times.Never);
        userRepositoryMOCK.Verify(x => x.Add(fakeUserEntityModel), Times.Never);
    }

    [Fact]
    public void UserService_DeleteUser_ShouldReturnVoid()
    {
        //  Arrange
        var userFactoryMOCK = new Mock<IUserFactory>();
        var userRepositoryMOCK = new Mock<IUserRepository>();

        var _sut = new UserService(userRepositoryMOCK.Object, userFactoryMOCK.Object);
        var fakeModel = new UserModel();

        //  Act
        _sut.DeleteUser(fakeModel);

        //  Assert
        userRepositoryMOCK.Verify(x => x.Delete(fakeModel), Times.Once);
    }
}
