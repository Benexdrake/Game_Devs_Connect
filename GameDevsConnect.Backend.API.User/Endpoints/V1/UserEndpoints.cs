namespace GameDevsConnect.Backend.API.User.Endpoints.V1;

public static class UserEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/user");

        // Get all User IDs
        group.MapGet("", async (IUserService service) =>
        {
            return await service.GetIdsAsync();
        });

        // Get a User by ID
        group.MapGet("{id}", async (IUserService service, string id) =>
        {
            return await service.GetAsync(id);
        });

        // Add a User
        group.MapPost("add", async (IUserService service, UserModel user) =>
        {
            return await service.AddAsync(user);
        });

        // Update a User
        group.MapPut("update", async (IUserService service, UserModel user) =>
        {
            return await service.UpdateAsync(user);
        });

        // Delete a User
        group.MapDelete("delete/{id}", async (IUserService service, string id) =>
        {
            return await service.DeleteAsync(id);
        });
    }
}
