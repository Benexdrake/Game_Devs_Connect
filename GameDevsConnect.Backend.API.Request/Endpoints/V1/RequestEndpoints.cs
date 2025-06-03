namespace GameDevsConnect.Backend.API.Request.Endpoints.V1;

public static class RequestEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/request");

        group.MapGet("", async ([FromServices] IRequestService service) =>
        {
            return await service.GetIdsAsync();
        });

        // Get Tags by Request Id
        group.MapGet("{id}", async ([FromServices] IRequestService service, [FromRoute] string id) =>
        {
            return await service.GetByIdAsync(id);
        });
        // Get Tags by Request Id
        group.MapGet("full/{id}", async ([FromServices] IRequestService service, [FromRoute] string id) =>
        {
            return await service.GetFullByIdAsync(id);
        });

        // Get Tags by Request Id
        group.MapGet("user/{id}", async ([FromServices] IRequestService service, [FromRoute] string id) =>
        {
            return await service.GetByUserIdAsync(id);
        });

        group.MapPost("add", async([FromServices]IRequestService service, [FromBody] AddRequest add) =>
        {
            return await service.AddAsync(add);
        });

        // Update a Tag
        group.MapPut("update", async ([FromServices] IRequestService service, [FromBody] RequestModel request) =>
        {
            return await service.UpdateAsync(request);
        });

        // Delete a Tag
        group.MapDelete("delete/{id}", async ([FromServices] IRequestService service, [FromRoute] string id) =>
        {
            return await service.DeleteAsync(id);
        });
    }
}
