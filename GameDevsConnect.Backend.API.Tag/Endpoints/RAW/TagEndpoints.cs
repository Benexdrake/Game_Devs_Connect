namespace GameDevsConnect.Backend.API.Tag.Endpoints.RAW;

public static class TagEndpoints
{
    public static void MapEndpointsRAW(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/raw/tag");

        // Get all Tags
        group.MapGet("", async ([FromServices] ITagRepository rep) =>
        {
            return await rep.GetAsync();
        });

        // Add a Tag
        group.MapPost("add", async ([FromServices] ITagRepository rep, [FromBody] TagModel tag) =>
        {
            return await rep.AddAsync(tag);
        });

        // Update a Tag
        group.MapPut("update", async ([FromServices] ITagRepository rep, [FromBody] TagModel tag) =>
        {
            return await rep.UpdateAsync(tag);
        });

        // Delete a Tag
        group.MapDelete("delete/{id}", async ([FromServices] ITagRepository rep, [FromRoute] int id) =>
        {
            return await rep.DeleteAsync(id);
        });
    }
}
