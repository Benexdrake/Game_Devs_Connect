namespace GameDevsConnect.Backend.API.Comment.Endpoints.V1;

public static class CommentEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Tag.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.Comment.Count, async ([FromServices] ICommentRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetCountByRequestIdAsync(id);
        })
        .WithName(ApiEndpointsV1.Comment.MetaData.Count)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Comment.Get, async ([FromServices] ICommentRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetByIdAsync(id);
        })
        .WithName(ApiEndpointsV1.Comment.MetaData.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Comment.GetByRequestId, async ([FromServices] ICommentRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetIdsByRequestIdAsync(id);
        })
        .WithName(ApiEndpointsV1.Comment.MetaData.GetByRequestId)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Comment.Create, async ([FromServices] ICommentRepository rep, [FromBody] CommentModel comment) =>
        {
            return await rep.AddAsync(comment);
        })
        .WithName(ApiEndpointsV1.Comment.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.Comment.Update, async ([FromServices] ICommentRepository rep, [FromBody] CommentModel comment) =>
        {
            return await rep.UpdateAsync(comment);
        })
        .WithName(ApiEndpointsV1.Comment.MetaData.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.Comment.Delete, async ([FromServices] ICommentRepository rep, [FromRoute] string id) =>
        {
            return await rep.DeleteAsync(id);
        })
        .WithName(ApiEndpointsV1.Comment.MetaData.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
