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
        .WithName(ApiEndpointsV1.User.MetaData.Name.GetIds)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.GetIds)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.Get, async ([FromServices] IUserRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.Get)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.Exist, async ([FromServices] IUserRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetExistAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.Exist)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.Exist)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.GetFollower, async ([FromServices] IUserRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetFollowerAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.GetFollower)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.GetFollower)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.GetFollowing, async ([FromServices] IUserRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetFollowingAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.GetFollowing)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.GetFollowing)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.GetFollowerCount, async ([FromServices] IUserRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetFollowerCountAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.GetFollowerCount)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.GetFollowerCount)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.GetFollowingCount, async ([FromServices] IUserRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetFollowingCountAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.GetFollowingCount)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.GetFollowingCount)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.GetIdsByProjectId, async ([FromServices] IUserRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetIdsByProjectIdAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.GetIdsByProjectId)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.GetIdsByProjectId)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.User.Create, async ([FromServices] IUserRepository repo, [FromBody] UserDTO user, CancellationToken token) =>
        {
            return await repo.AddAsync(user, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.Create)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.User.Update, async ([FromServices] IUserRepository repo, [FromBody] UserDTO user, CancellationToken token) =>
        {
            return await repo.UpdateAsync(user, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.Update)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.User.Delete, async ([FromServices] IUserRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.DeleteAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.Delete)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
