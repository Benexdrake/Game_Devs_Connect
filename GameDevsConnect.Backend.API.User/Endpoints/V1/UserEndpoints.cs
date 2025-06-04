namespace GameDevsConnect.Backend.API.User.Endpoints.V1;

public static class UserEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/user");

        // Get all User IDs
        group.MapGet("", async ([FromServices] IUserRepository repo) =>
        {
            return await repo.GetIdsAsync();
        });

        // Get a User by ID
        group.MapGet("{id}", async ([FromServices] IUserRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetAsync(id);
        });

        // Add a User
        group.MapPost("add", async ([FromServices] IUserRepository repo, [FromBody] UserModel user) =>
        {
            return await repo.AddAsync(user);
        });

        // Update a User
        group.MapPut("update", async ([FromServices] IUserRepository repo, [FromBody] UserModel user) =>
        {
            return await repo.UpdateAsync(user);
        });

        // Delete a User
        group.MapDelete("delete/{id}", async ([FromServices] IUserRepository repo, [FromRoute] string id) =>
        {
            return await repo.DeleteAsync(id);
        });
    }
}
