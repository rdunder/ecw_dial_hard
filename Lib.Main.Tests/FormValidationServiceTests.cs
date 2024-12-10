using Lib.Main.Core.Models;
using Lib.Main.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Main.Tests
{
    public class FormValidationServiceTests
    {
        [Fact]
        public void Validate_ShouldReturnNull()
        {
            //  Arrange
            var _sut = new FormValidationService();
            var fakeValidModel = new UserFormModel()
            {
                FirstName = "Fake",
                LastName = "Fale",
                Email = "fake@domain.com",
                PhoneNumber = "1234567890",
            };

            //  Act
            var result = _sut.Validate(fakeValidModel);

            //  Assert
            Assert.Null(result);
        }

        [Fact]
        public void Validate_ShouldReturnValidationResults()
        {
            var _sut = new FormValidationService();
            var fakeValidModel = new UserFormModel()
            {
                FirstName = "",
                LastName = "",
                Email = "",
                PhoneNumber = "1234567890",
            };

            //  Act
            var result = _sut.Validate(fakeValidModel);

            //  Assert
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }
    }
}
