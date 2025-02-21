namespace Backend.Test;
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
        A.CallTo(() => _userRepository.AddUserAsync(user));
        var result = (OkObjectResult)await _userController.AddUserAsync(user);

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_A_User_By_ID_From_Controller()
    {
        // Arrange
        var user = CreateFakeUser();

        // Act
        A.CallTo(() => _userRepository.GetShortUserAsync(user.Id));
        var result = (OkObjectResult)await _userController.GetUserAsync(user.Id);

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_All_Users_From_Comtroller()
    {
        // Arrange
        var user = CreateFakeUser();

        // Act
        A.CallTo(() => _userRepository.GetUsersAsync());
        var result = (OkObjectResult)await _userController.GetUsersAsync();

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Update_A_User_From_Controller()
    {
        // Arrange
        var user = CreateFakeUser();

        // Act
        A.CallTo(() => _userRepository.UpdateUserAsync(user));
        var result = (OkObjectResult)await _userController.UpdateUserAsync(user);

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Delete_A_User_From_Controller()
    {
        // Arrange
        var user = CreateFakeUser();

        // Act
        A.CallTo(() => _userRepository.DeleteUserAsync(user.Id));
        var result = (OkObjectResult)await _userController.DeleteUserAsync(user.Id);

        // Assert
        result.StatusCode.Should().Be(200);
    }
}