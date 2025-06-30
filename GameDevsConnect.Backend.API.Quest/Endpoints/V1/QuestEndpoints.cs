namespace GameDevsConnect.Backend.API.Quest.Endpoints.V1;

public static class QuestEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Quest.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.Quest.GetIdsByPostId, async ([FromServices] IQuestRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetByPostIdAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Quest.MetaData.GetIdsByPostId)
        .WithDescription("HELLO")
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Quest.Get, async ([FromServices] IQuestRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Quest.MetaData.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Quest.Create, async ([FromServices] IQuestRepository repo, [FromBody] QuestDTO quest, CancellationToken token) =>
        {
            return await repo.AddAsync(quest, token);
        })
        .WithName(ApiEndpointsV1.Quest.MetaData.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.Quest.Update, async ([FromServices] IQuestRepository repo, [FromBody] QuestDTO quest, CancellationToken token) =>
        {
            return await repo.UpdateAsync(quest, token);
        })
        .WithName(ApiEndpointsV1.Quest.MetaData.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.Quest.Delete, async ([FromServices] IQuestRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.DeleteAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Quest.MetaData.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
