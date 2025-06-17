namespace GameDevsConnect.Backend.API.User.Endpoints.V1;

public static class UserEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.User.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.User.GetIds, async ([FromServices] IUserRepository repo, CancellationToken token) =>
        {
            return await repo.GetIdsAsync(token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.GetIds)
        .WithDescription("HELLO")
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.Get, async ([FromServices] IUserRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.Exist, async ([FromServices] IUserRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetExistAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Exist)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.User.Create, async ([FromServices] IUserRepository repo, [FromBody] UserModel user, CancellationToken token) =>
        {
            return await repo.AddAsync(user, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.User.Update, async ([FromServices] IUserRepository repo, [FromBody] UserModel user, CancellationToken token) =>
        {
            return await repo.UpdateAsync(user, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.User.Delete, async ([FromServices] IUserRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.DeleteAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
