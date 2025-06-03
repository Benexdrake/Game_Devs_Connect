namespace GameDevsConnect.Backend.API.Tag.Endpoints.V1;

public static class TagEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/tag");

        // Get all Tags
        group.MapGet("", async ([FromServices] ITagService service) =>
        {
            return await service.GetAsync();
        });

        // Add a Tag
        group.MapPost("add", async ([FromServices] ITagService service, [FromBody] TagModel tag) =>
        {
            return await service.AddAsync(tag);
        });

        // Update a Tag
        group.MapPut("update", async ([FromServices] ITagService service, [FromBody] TagModel tag) =>
        {
            return await service.UpdateAsync(tag);
        });

        // Delete a Tag
        group.MapDelete("delete/{id}", async ([FromServices] ITagService service, [FromRoute] int id) =>
        {
            return await service.DeleteAsync(id);
        });
    }
}
