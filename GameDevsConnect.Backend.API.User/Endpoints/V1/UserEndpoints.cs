namespace GameDevsConnect.Backend.API.User.Endpoints.V1;

public static class UserEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/user");

        // Get all User IDs
        group.MapGet("", async ([FromServices] IUserService service) =>
        {
            return await service.GetIdsAsync();
        })
        .WithName("UserV1")
        .Produces<APIResponse>(StatusCodes.Status200OK);

        // Get a User by ID
        group.MapGet("{id}", async ([FromServices] IUserService service, [FromRoute] string id) =>
        {
            return await service.GetAsync(id);
        });

        // Add a User
        group.MapPost("add", async ([FromServices] IUserService service, [FromBody] UserModel user) =>
        {
            return await service.AddAsync(user);
        });

        // Update a User
        group.MapPut("update", async ([FromServices] IUserService service, [FromBody] UserModel user) =>
        {
            return await service.UpdateAsync(user);
        });

        // Delete a User
        group.MapDelete("delete/{id}", async ([FromServices] IUserService service, [FromRoute] string id) =>
        {
            return await service.DeleteAsync(id);
        });
    }
}
