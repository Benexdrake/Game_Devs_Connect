namespace Backend.Test;
public class RequestTest
{
    private readonly IRequestRepository _repository;
    private readonly RequestController _controller;

    public RequestTest()
    {
        _repository = A.Fake<IRequestRepository>();
        _controller = new RequestController(_repository);
    }

    private static Request CreateFakeRequest() => A.Fake<Request>();

    [Fact]
    public async Task Create_Request_From_Controller()
    {
        // Arrange
        var request = CreateFakeRequest();

        // Act
        A.CallTo(() => _repository.AddRequest(request)).Returns(true);
        var result = (OkObjectResult)await _controller.AddRequest(request);

        // Assert
        result.StatusCode.Should().Be(200);
        result.Value.Should().Be(true);
    }

    [Fact]
    public async Task Get_A_Request_By_ID()
    {
        // Arrange
        var request = CreateFakeRequest();

        // Act
        A.CallTo(() => _repository.GetRequestById(request.Id)).Returns(request);
        var result = (OkObjectResult)await _controller.GetRequestById(request.Id);

        // Assert
        result.StatusCode.Should().Be(200);
        result.Value.Should().Be(request);
    }

    [Fact]
    public async Task Get_All_Requests()
    {
        // Arrange
        

        // Act
        A.CallTo(() => _repository.GetRequests());
        var result = (OkObjectResult)await _controller.GetRequests();

        // Assert
        result.StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task Update_A_Request()
    {
        // Arrange
        var request = CreateFakeRequest();

        // Act
        A.CallTo(() => _repository.UpdateRequest(request)).Returns(true);
        var result = (OkObjectResult)await _controller.UpdateRequest(request);

        // Assert
        result.StatusCode.Should().Be(200);
        result.Value.Should().Be(true);
    }

    [Fact]
    public async Task Delete_A_Request()
    {
        // Arrange
        var request = CreateFakeRequest();

        // Act
        A.CallTo(() => _repository.DeleteRequest(request.Id)).Returns(true);
        var result = (OkObjectResult)await _controller.DeleteRequest(request.Id);

        // Assert
        result.StatusCode.Should().Be(200);
        result.Value.Should().Be(true);
    }
}
