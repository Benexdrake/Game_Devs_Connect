namespace GameDevsConnect.Backend.API.Profile.Endpoints.V1
{
    public static class ProfileEndpoints
    {
        public static void MapEndpointsV1(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/v1/profile");


            // Get a Profile by ID
            group.MapGet("{id}", async ([FromServices] IProfileRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetAsync(id);
            });

            // Get a Profile by ID
            group.MapGet("full/{id}", async ([FromServices] IProfileRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetFullAsync(id);
            });

            // Add a Profile
            group.MapPost("add", async ([FromServices] IProfileRepository rep, [FromBody] ProfileModel profile) =>
            {
                return await rep.AddAsync(profile);
            });

            // Update a Profile
            group.MapPut("update", async ([FromServices] IProfileRepository rep, [FromBody] ProfileModel profile) =>
            {
                return await rep.UpdateAsync(profile);
            });

            // Delete a Profile
            group.MapDelete("delete/{id}", async ([FromServices] IProfileRepository rep, [FromRoute] string id) =>
            {
                return await rep.DeleteAsync(id);
            });
        }
    }
}
