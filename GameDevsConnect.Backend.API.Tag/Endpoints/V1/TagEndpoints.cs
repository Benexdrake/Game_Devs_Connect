namespace GameDevsConnect.Backend.API.Tag.Endpoints.V1;

public static class TagEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/tag");

        // Get all Tags
        group.MapGet("", async ([FromServices] ITagRepository repo) =>
        {
            return await repo.GetAsync();
        });

        // Add a Tag
        group.MapPost("add", async ([FromServices] ITagRepository repo, [FromBody] TagModel tag) =>
        {
            return await repo.AddAsync(tag);
        });

        // Update a Tag
        group.MapPut("update", async ([FromServices] ITagRepository repo, [FromBody] TagModel tag) =>
        {
            return await repo.UpdateAsync(tag);
        });

        // Delete a Tag
        group.MapDelete("delete/{id}", async ([FromServices] ITagRepository repo, [FromRoute] int id) =>
        {
            return await repo.DeleteAsync(id);
        });
    }
}
