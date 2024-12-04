using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Main.Core.Models;
using Lib.Main.Services;
using Lib.Main.Services.Factories;

namespace Lib.Main.Tests
{
    public class UserFactoryTest
    {        
        private readonly UserFactory _userFactory;

        public UserFactoryTest()
        {
            _userFactory = new UserFactory(); 
        }



        [Fact]
        public void UserFacory_Create_ShouldReturnNewUserFormModel()
        {
            //  Arrange

            //  Act
            UserFormModel result = _userFactory.Create();

            //  Assert
            Assert.NotNull(result);
            Assert.IsType<UserFormModel>(result);
        }

        [Fact]
        public void UserFactory_Create_ShouldReturnNewUserEntity()
        {
            //  Arrange
            UserFormModel fakeFormModel = new UserFormModel()
            {
                FirstName = "FakeName",
                LastName = "FakeName",
                Email = "fake.name@domain.com",
                PhoneNumber = "1234567890",
                Adress = "",
                PostalCode = "",
                County = ""
            };

            //  Act
            UserEntity result = _userFactory.Create(fakeFormModel);

            //  Assert
            Assert.NotNull(result);
            Assert.IsType<UserEntity>(result);
        }

        [Fact]
        public void UserFactory_Create_ShouldReturnNewUserModel()
        {
            //  Arrange
            UserEntity fakeEntityModel = new UserEntity()
            {
                Id = Guid.NewGuid(),
                FirstName = "FakeName",
                LastName = "FakeName",
                Email = "fake.name@domain.com",
                PhoneNumber = "1234567890",
                Adress = "",
                PostalCode = "",
                County = "",
                EmailConfirmed = false
            };

            //  Act
            UserModel result = _userFactory.Create(fakeEntityModel);

            //  Assert
            Assert.NotNull(result);
            Assert.IsType<UserModel>(result);
        }
    }
}
