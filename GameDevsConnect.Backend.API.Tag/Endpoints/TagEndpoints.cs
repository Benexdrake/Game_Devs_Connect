namespace GameDevsConnect.Backend.API.Tag.Endpoints
{
    public static class TagEndpoints
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/tag");

            // Get all Tags
            group.MapGet("", async (ITagRepository rep) =>
            {
                return await rep.GetIdsAsync();
            });

            // Get Tags by Request Id
            group.MapGet("{id}", async (ITagRepository rep, int id) =>
            {
                return await rep.GetAsync(id);
            });

            // Add a Tag
            group.MapPost("add", async (ITagRepository rep, TagModel tag) =>
            {
                return await rep.AddAsync(tag);
            });

            // Update a Tag
            group.MapPut("update", async (ITagRepository rep, TagModel tag) =>
            {
                return await rep.UpdateAsync(tag);
            });

            // Delete a Tag
            group.MapDelete("delete/{id}", async (ITagRepository rep, int id) =>
            {
                return await rep.DeleteAsync(id);
            });
        }
    }
}
