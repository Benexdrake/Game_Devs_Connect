using GameDevsConnect.Backend.API.User.Application.Repository;

namespace GameDevsConnect.Backend.API.User.Endpoints.RAW;

public static class UserEndpointsRAW
{
    public static void MapEndpointsRAW(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/raw/user");

        // Get all User IDs
        group.MapGet("", async (IUserRepository repo) =>
        {
            return await repo.GetIdsAsync();
        });

        // Get a User by ID
        group.MapGet("{id}", async (IUserRepository repo, string id) =>
        {
            return await repo.GetAsync(id);
        });

        // Add a User
        group.MapPost("add", async (IUserRepository repo, UserModel user) =>
        {
            return await repo.AddAsync(user);
        });

        // Update a User
        group.MapPut("update", async (IUserRepository repo, UserModel user) =>
        {
            return await repo.UpdateAsync(user);
        });

        // Delete a User
        group.MapDelete("delete/{id}", async (IUserRepository repo, string id) =>
        {
            return await repo.DeleteAsync(id);
        });
    }
}
