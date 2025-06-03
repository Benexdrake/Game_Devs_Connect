namespace GameDevsConnect.Backend.API.Request.Endpoints.RAW;

public static class RequestEndpoints
{
    public static void MapEndpointsRAW(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/raw/request");

        group.MapGet("", async ([FromServices] IRequestRepository rep) =>
        {
            return await rep.GetIdsAsync();
        });

        // Get Tags by Request Id
        group.MapGet("{id}", async ([FromServices] IRequestRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetByIdAsync(id);
        });
        // Get Tags by Request Id
        group.MapGet("full/{id}", async ([FromServices] IRequestRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetFullByIdAsync(id);
        });

        // Get Tags by Request Id
        group.MapGet("user/{id}", async ([FromServices] IRequestRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetByUserIdAsync(id);
        });

        group.MapPost("add", async([FromServices]IRequestRepository rep, [FromBody] AddRequest add) =>
        {
            return await rep.AddAsync(add);
        });

        // Update a Tag
        group.MapPut("update", async ([FromServices] IRequestRepository rep, [FromBody] RequestModel request) =>
        {
            return await rep.UpdateAsync(request);
        });

        // Delete a Tag
        group.MapDelete("delete/{id}", async ([FromServices] IRequestRepository rep, [FromRoute] string id) =>
        {
            return await rep.DeleteAsync(id);
        });
    }
}
