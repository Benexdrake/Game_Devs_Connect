namespace GameDevsConnect.Backend.API.Request.Endpoints.V1;

public static class RequestEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(ApiEndpoints.Request.Group);

        group.MapGet(ApiEndpoints.Request.Get, async ([FromServices] IRequestRepository repo) =>
        {
            return await repo.GetIdsAsync();
        })
            .WithName(ApiEndpoints.Request.MetaData.Get)
            .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpoints.Request.GetByRequestId, async ([FromServices] IRequestRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetByIdAsync(id);
        })
            .WithName(ApiEndpoints.Request.MetaData.GetByRequestId)
            .Produces(StatusCodes.Status200OK);
        
        group.MapGet(ApiEndpoints.Request.GetFull, async ([FromServices] IRequestRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetFullByIdAsync(id);
        })
            .WithName(ApiEndpoints.Request.MetaData.GetFull)
            .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpoints.Request.GetByUserId, async ([FromServices] IRequestRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetByUserIdAsync(id);
        })
            .WithName(ApiEndpoints.Request.MetaData.GetByUserId)
            .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpoints.Request.Create, async([FromServices]IRequestRepository repo, [FromBody] AddRequest add) =>
        {
            return await repo.AddAsync(add);
        })
            .WithName(ApiEndpoints.Request.MetaData.Create)
            .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpoints.Request.Update, async ([FromServices] IRequestRepository repo, [FromBody] RequestModel request) =>
        {
            return await repo.UpdateAsync(request);
        })
            .WithName(ApiEndpoints.Request.MetaData.Update)
            .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpoints.Request.Delete, async ([FromServices] IRequestRepository repo, [FromRoute] string id) =>
        {
            return await repo.DeleteAsync(id);
        })
            .WithName(ApiEndpoints.Request.MetaData.Delete)
            .Produces(StatusCodes.Status200OK);
    }
}
