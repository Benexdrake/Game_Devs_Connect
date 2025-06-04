namespace GameDevsConnect.Backend.API.User.Endpoints.V1;

public static class UserEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(ApiEndpoints.User.Group);

        group.MapGet(ApiEndpoints.User.GetIds, async ([FromServices] IUserRepository repo, CancellationToken token) =>
        {
            return await repo.GetIdsAsync(token);
        })
        .WithName(ApiEndpoints.User.MetaData.GetIds)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpoints.User.Get, async ([FromServices] IUserRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetAsync(id, token);
        })
        .WithName(ApiEndpoints.User.MetaData.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpoints.User.Create, async ([FromServices] IUserRepository repo, [FromBody] UserModel user, CancellationToken token) =>
        {
            return await repo.AddAsync(user, token);
        })
        .WithName(ApiEndpoints.User.MetaData.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpoints.User.Update, async ([FromServices] IUserRepository repo, [FromBody] UserModel user, CancellationToken token) =>
        {
            return await repo.UpdateAsync(user, token);
        })
        .WithName(ApiEndpoints.User.MetaData.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpoints.User.Delete, async ([FromServices] IUserRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.DeleteAsync(id, token);
        })
        .WithName(ApiEndpoints.User.MetaData.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
