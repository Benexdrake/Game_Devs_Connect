namespace Backend.Test;
public class ProjectTest
{
    private readonly IProjectRepository _repository;
    private readonly ProjectController _controller;

    public ProjectTest()
    {
        _repository = A.Fake<IProjectRepository>();
        _controller = new ProjectController(_repository);
    }

    private static Project CreateFakeProject() => A.Fake<Project>();

    [Fact]
    public async Task Create_Project()
    {
        // Arrange
        var project = CreateFakeProject();

        // Act
        A.CallTo(() => _repository.AddProject(project)).Returns(true);
        var result = (OkObjectResult)await _controller.AddProject(project);

        // Assert
        result.StatusCode.Should().Be(200);
        result.Value.Should().Be(true);
    }

    [Fact]
    public async Task Get_A_Project()
    {
        // Arrange
        var project = CreateFakeProject();

        // Act
        A.CallTo(() => _repository.GetProject(project.Id)).Returns<Project>(project);
        var result = (OkObjectResult)await _controller.GetProject(project.Id);

        // Assert
        result.StatusCode.Should().Be(200);
        result.Value.Should().Be(project);
    }

    [Fact]
    public async Task Update_A_Project()
    {
        // Arrange
        var project = CreateFakeProject();

        // Act
        A.CallTo(() => _repository.UpdateProject(project)).Returns(true);
        var result = (OkObjectResult)await _controller.UpdateProject(project);

        // Assert
        result.StatusCode.Should().Be(200);
        result.Value.Should().Be(true);
    }

    [Fact]
    public async Task Delete_A_Project()
    {
        // Arrange
        var project = CreateFakeProject();

        // Act
        A.CallTo(() => _repository.DeleteProject(project.Id)).Returns(true);
        var result = (OkObjectResult)await _controller.DeleteProject(project.Id);

        // Assert
        result.StatusCode.Should().Be(200);
        result.Value.Should().Be(true);
    }
}
