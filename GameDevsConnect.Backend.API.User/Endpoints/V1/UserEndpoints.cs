namespace GameDevsConnect.Backend.API.User.Endpoints.V1;

public static class UserEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.User.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.User.GetIds, async ([FromServices] IUserService service, CancellationToken token) =>
        {
            return await service.GetIdsAsync(token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.GetIds)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.GetIds)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.Get, async ([FromServices] IUserService service, [FromRoute] string id, CancellationToken token) =>
        {
            return await service.GetAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.Get)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.Exist, async ([FromServices] IUserService service, [FromRoute] string id, CancellationToken token) =>
        {
            return await service.GetExistAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.Exist)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.Exist)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.GetFollower, async ([FromServices] IUserService service, [FromRoute] string id, CancellationToken token) =>
        {
            return await service.GetFollowerAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.GetFollower)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.GetFollower)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.GetFollowing, async ([FromServices] IUserService service, [FromRoute] string id, CancellationToken token) =>
        {
            return await service.GetFollowingAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.GetFollowing)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.GetFollowing)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.GetFollowerCount, async ([FromServices] IUserService service, [FromRoute] string id, CancellationToken token) =>
        {
            return await service.GetFollowerCountAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.GetFollowerCount)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.GetFollowerCount)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.GetFollowingCount, async ([FromServices] IUserService service, [FromRoute] string id, CancellationToken token) =>
        {
            return await service.GetFollowingCountAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.GetFollowingCount)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.GetFollowingCount)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.User.GetIdsByProjectId, async ([FromServices] IUserService service, [FromRoute] string id, CancellationToken token) =>
        {
            return await service.GetIdsByProjectIdAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.GetIdsByProjectId)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.GetIdsByProjectId)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.User.Create, async ([FromServices] IUserService service, [FromBody] UserDTO user, CancellationToken token) =>
        {
            return await service.AddAsync(user, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.Create)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.User.Update, async ([FromServices] IUserService service, [FromBody] UserDTO user, CancellationToken token) =>
        {
            return await service.UpdateAsync(user, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.Update)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.User.Delete, async ([FromServices] IUserService service, [FromRoute] string id, CancellationToken token) =>
        {
            return await service.DeleteAsync(id, token);
        })
        .WithName(ApiEndpointsV1.User.MetaData.Name.Delete)
        .WithDescription(ApiEndpointsV1.User.MetaData.Description.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
