namespace GameDevsConnect.Backend.API.Request.Endpoints.V1;

public static class RequestEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/request");

        group.MapGet("", async ([FromServices] IRequestRepository repo) =>
        {
            return await repo.GetIdsAsync();
        });

        // Get Tags by Request Id
        group.MapGet("{id}", async ([FromServices] IRequestRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetByIdAsync(id);
        });
        // Get Tags by Request Id
        group.MapGet("full/{id}", async ([FromServices] IRequestRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetFullByIdAsync(id);
        });

        // Get Tags by Request Id
        group.MapGet("user/{id}", async ([FromServices] IRequestRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetByUserIdAsync(id);
        });

        group.MapPost("add", async([FromServices]IRequestRepository repo, [FromBody] AddRequest add) =>
        {
            return await repo.AddAsync(add);
        });

        // Update a Tag
        group.MapPut("update", async ([FromServices] IRequestRepository repo, [FromBody] RequestModel request) =>
        {
            return await repo.UpdateAsync(request);
        });

        // Delete a Tag
        group.MapDelete("delete/{id}", async ([FromServices] IRequestRepository repo, [FromRoute] string id) =>
        {
            return await repo.DeleteAsync(id);
        });
    }
}
