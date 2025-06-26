namespace GameDevsConnect.Backend.API.Request.Endpoints.V1;

public static class RequestEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Request.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.Request.Get, async ([FromServices] IRequestRepository repo) =>
        {
            return await repo.GetIdsAsync();
        })
            .WithName(ApiEndpointsV1.Request.MetaData.Get)
            .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Request.GetByRequestId, async ([FromServices] IRequestRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetByIdAsync(id);
        })
            .WithName(ApiEndpointsV1.Request.MetaData.GetByRequestId)
            .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Request.GetFull, async ([FromServices] IRequestRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetFullByIdAsync(id);
        })
            .WithName(ApiEndpointsV1.Request.MetaData.GetFull)
            .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Request.GetByUserId, async ([FromServices] IRequestRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetByUserIdAsync(id);
        })
            .WithName(ApiEndpointsV1.Request.MetaData.GetByUserId)
            .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Request.Create, async ([FromServices] IRequestRepository repo, [FromBody] AddRequest add) =>
        {
            return await repo.AddAsync(add);
        })
            .WithName(ApiEndpointsV1.Request.MetaData.Create)
            .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.Request.Update, async ([FromServices] IRequestRepository repo, [FromBody] RequestModel request) =>
        {
            return await repo.UpdateAsync(request);
        })
            .WithName(ApiEndpointsV1.Request.MetaData.Update)
            .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.Request.Delete, async ([FromServices] IRequestRepository repo, [FromRoute] string id) =>
        {
            return await repo.DeleteAsync(id);
        })
            .WithName(ApiEndpointsV1.Request.MetaData.Delete)
            .Produces(StatusCodes.Status200OK);
    }
}
