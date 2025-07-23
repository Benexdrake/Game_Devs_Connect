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
        .WithName(ApiEndpointsV1.Quest.MetaData.Name.GetIdsByPostId)
        .WithDescription(ApiEndpointsV1.Quest.MetaData.Description.GetIdsByPostId)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Quest.Get, async ([FromServices] IQuestRepository repo, [FromRoute] string id, [FromQuery] string userId, CancellationToken token) =>
        {
            return await repo.GetAsync(id, userId, token);
        })
        .WithName(ApiEndpointsV1.Quest.MetaData.Name.Get)
        .WithDescription(ApiEndpointsV1.Quest.MetaData.Description.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Quest.GetFavorites, async ([FromServices] IQuestRepository repo, [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string searchTerm = "", [FromQuery] string userId = "", CancellationToken token = default) =>
        {
            return await repo.GetFavoritesAsync(page, pageSize, searchTerm, userId, token);
        })
        .WithName(ApiEndpointsV1.Quest.MetaData.Name.GetFavorites)
        .WithDescription(ApiEndpointsV1.Quest.MetaData.Description.GetFavorites)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Quest.Create, async ([FromServices] IQuestRepository repo, [FromBody] QuestDTO quest, CancellationToken token) =>
        {
            return await repo.AddAsync(quest, token);
        })
        .WithName(ApiEndpointsV1.Quest.MetaData.Name.Create)
        .WithDescription(ApiEndpointsV1.Quest.MetaData.Description.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Quest.Complete, async ([FromServices] IQuestRepository repo, [FromBody] CompleteQuestRequest complete, CancellationToken token) =>
        {
            return await repo.CompleteAsync(complete, token);
        })
        .WithName(ApiEndpointsV1.Quest.MetaData.Name.Complete)
        .WithDescription(ApiEndpointsV1.Quest.MetaData.Description.Complete)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.Quest.Update, async ([FromServices] IQuestRepository repo, [FromBody] QuestDTO quest, CancellationToken token) =>
        {
            return await repo.UpdateAsync(quest, token);
        })
        .WithName(ApiEndpointsV1.Quest.MetaData.Name.Update)
        .WithDescription(ApiEndpointsV1.Quest.MetaData.Description.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.Quest.Delete, async ([FromServices] IQuestRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.DeleteAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Quest.MetaData.Name.Delete)
        .WithDescription(ApiEndpointsV1.Quest.MetaData.Description.Delete)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Quest.Favorite, async ([FromServices] IQuestRepository repo, [FromBody] FavoriteQuestResponse favoriteQuestResponse, CancellationToken token) =>
        {
            return await repo.UpsertFavoriteQuestAsync(favoriteQuestResponse, token);
        })
        .WithName(ApiEndpointsV1.Quest.MetaData.Name.Favorite)
        .WithDescription(ApiEndpointsV1.Quest.MetaData.Description.Favorite)
        .Produces(StatusCodes.Status200OK);
    }
}
