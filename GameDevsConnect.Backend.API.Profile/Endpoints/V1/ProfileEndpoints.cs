using GameDevsConnect.Backend.API.Configuration;

namespace GameDevsConnect.Backend.API.Profile.Endpoints.V1;
public static class ProfileEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(ApiEndpoints.Profile.Group);

        group.MapGet(ApiEndpoints.Profile.Get, async ([FromServices] IProfileRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetAsync(id);
        })
        .WithName(ApiEndpoints.Profile.MetaData.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpoints.Profile.GetFull, async ([FromServices] IProfileRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetFullAsync(id);
        })
        .WithName(ApiEndpoints.Profile.MetaData.GetFull)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpoints.Profile.Create, async ([FromServices] IProfileRepository rep, [FromBody] ProfileModel profile) =>
        {
            return await rep.AddAsync(profile);
        })
        .WithName(ApiEndpoints.Profile.MetaData.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpoints.Profile.Update, async ([FromServices] IProfileRepository rep, [FromBody] ProfileModel profile) =>
        {
            return await rep.UpdateAsync(profile);
        })
        .WithName(ApiEndpoints.Profile.MetaData.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpoints.Profile.Delete, async ([FromServices] IProfileRepository rep, [FromRoute] string id) =>
        {
            return await rep.DeleteAsync(id);
        })
        .WithName(ApiEndpoints.Profile.MetaData.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
