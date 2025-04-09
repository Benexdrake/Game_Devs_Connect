namespace GameDevsConnect.Backend.API.Profile.Endpoints
{
    public static class ProfileEndpoints
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/profile");


            // Get a Profile by ID
            group.MapGet("{id}", async (IProfileRepository rep, string id) =>
            {
                return await rep.GetAsync(id);
            });

            // Add a Profile
            group.MapPost("add", async (IProfileRepository rep, ProfileModel profile) =>
            {
                return await rep.AddAsync(profile);
            });

            // Update a Profile
            group.MapPut("update", async (IProfileRepository rep, ProfileModel profile) =>
            {
                return await rep.UpdateAsync(profile);
            });

            // Delete a Profile
            group.MapDelete("delete/{id}", async (IProfileRepository rep, string id) =>
            {
                return await rep.DeleteAsync(id);
            });
        }
    }
}
