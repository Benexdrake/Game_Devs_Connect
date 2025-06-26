namespace GameDevsConnect.Backend.API.Profile.Endpoints.V1;
public static class ProfileEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Profile.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.Profile.Get, async ([FromServices] IProfileRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetAsync(id);
        })
        .WithName(ApiEndpointsV1.Profile.MetaData.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Profile.GetFull, async ([FromServices] IProfileRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetFullAsync(id);
        })
        .WithName(ApiEndpointsV1.Profile.MetaData.GetFull)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Profile.Create, async ([FromServices] IProfileRepository rep, [FromBody] ProfileModel profile) =>
        {
            return await rep.AddAsync(profile);
        })
        .WithName(ApiEndpointsV1.Profile.MetaData.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.Profile.Update, async ([FromServices] IProfileRepository rep, [FromBody] ProfileModel profile) =>
        {
            return await rep.UpdateAsync(profile);
        })
        .WithName(ApiEndpointsV1.Profile.MetaData.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.Profile.Delete, async ([FromServices] IProfileRepository rep, [FromRoute] string id) =>
        {
            return await rep.DeleteAsync(id);
        })
        .WithName(ApiEndpointsV1.Profile.MetaData.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
