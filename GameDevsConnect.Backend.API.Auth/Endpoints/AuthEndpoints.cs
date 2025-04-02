namespace GameDevsConnect.Backend.API.Auth.Endpoints
{
    public static class AuthEndpoints
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/auth");

            // Get Auths by Request Id
            group.MapGet("{id}", async (IAuthRepository rep, string id) =>
            {
                return await rep.Get(id);
            });

            // Add a Auth
            group.MapPost("add", async (IAuthRepository rep, AuthModel auth) =>
            {
                return await rep.Add(auth);
            });

            // Update a Auth
            group.MapPut("update", async (IAuthRepository rep, AuthModel auth) =>
            {
                return await rep.Update(auth);
            });

            // Delete a Auth
            group.MapDelete("delete/{id}", async (IAuthRepository rep, string id) =>
            {
                return await rep.Delete(id);
            });
        }
    }
}
