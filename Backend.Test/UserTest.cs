using Backend.Controllers;
using Backend.Interfaces;
using Backend.Models;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Test
{
    public class UserTest
    {
        private readonly IUserRepository _userRepository;
        private readonly UserController _userController;
        public UserTest()
        {
            _userRepository = A.Fake<IUserRepository>();
            _userController = new UserController(_userRepository);
        }

        private static User CreateFakeUser() => A.Fake<User>();

        [Fact]
        public async Task Create_User_And_Adding_With_Controller_To_DB()
        {
            // Arrange
            var user = CreateFakeUser();

            // Act
            A.CallTo(() => _userRepository.AddUserAsync(user)).Returns(true);
            var result = (OkObjectResult)await _userController.AddUserAsync(user);

            // Assert
            result.StatusCode.Should().Be(200);
            result.Should().NotBeNull();
        }
    }
}