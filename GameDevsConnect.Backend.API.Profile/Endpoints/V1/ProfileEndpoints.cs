namespace GameDevsConnect.Backend.API.Profile.Endpoints.V1;
public static class ProfileEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Profile.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.Profile.Get, async ([FromServices] IProfileRepository rep, [FromRoute] string id, CancellationToken token) =>
        {
            return await rep.GetAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Profile.MetaData.Name.Get)
        .WithDescription(ApiEndpointsV1.Profile.MetaData.Description.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Profile.GetFull, async ([FromServices] IProfileRepository rep, [FromRoute] string id, CancellationToken token) =>
        {
            return await rep.GetFullAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Profile.MetaData.Name.GetFull)
        .WithDescription(ApiEndpointsV1.Profile.MetaData.Description.GetFull)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Profile.Create, async ([FromServices] IProfileRepository rep, [FromRoute] string id, CancellationToken token) =>
        {
            return await rep.AddAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Profile.MetaData.Name.Create)
        .WithDescription(ApiEndpointsV1.Profile.MetaData.Description.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.Profile.Update, async ([FromServices] IProfileRepository rep, [FromBody] ProfileDTO profile, CancellationToken token) =>
        {
            return await rep.UpdateAsync(profile, token);
        })
        .WithName(ApiEndpointsV1.Profile.MetaData.Name.Update)
        .WithDescription(ApiEndpointsV1.Profile.MetaData.Description.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.Profile.Delete, async ([FromServices] IProfileRepository rep, [FromRoute] string id, CancellationToken token) =>
        {
            return await rep.DeleteAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Profile.MetaData.Name.Delete)
        .WithDescription(ApiEndpointsV1.Profile.MetaData.Description.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
