namespace GameDevsConnect.Backend.API.User.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/user");

            // Get all User IDs
            group.MapGet("", async (IUserRepository rep) =>
            {
                return await rep.GetIdsAsync();
            });

            // Get a User by ID
            group.MapGet("{id}", async (IUserRepository rep, string id) =>
            {
                return await rep.GetAsync(id);
            });

            // Add a User
            group.MapPost("add", async (IUserRepository rep, UserModel user) =>
            {
                return await rep.AddAsync(user);
            });

            // Update a User
            group.MapPut("update", async (IUserRepository rep, UserModel user) =>
            {
                return await rep.UpdateAsync(user);
            });

            // Delete a User
            group.MapDelete("delete/{id}", async (IUserRepository rep, string id) =>
            {
                return await rep.DeleteAsync(id);
            });
        }
    }
}
