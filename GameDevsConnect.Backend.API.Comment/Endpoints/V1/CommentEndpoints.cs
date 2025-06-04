namespace GameDevsConnect.Backend.API.Comment.Endpoints.V1
{
    public static class CommentEndpoints
    {
        public static void MapEndpointsV1(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup(ApiEndpoints.Comment.Group);

            group.MapGet(ApiEndpoints.Comment.Count, async ([FromServices] ICommentRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetCountByRequestIdAsync(id);
            })
            .WithName(ApiEndpoints.Comment.MetaData.Count)
            .Produces(StatusCodes.Status200OK);

            group.MapGet(ApiEndpoints.Comment.Get, async ([FromServices] ICommentRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetByIdAsync(id);
            })
            .WithName(ApiEndpoints.Comment.MetaData.Get)
            .Produces(StatusCodes.Status200OK);

            group.MapGet(ApiEndpoints.Comment.GetByRequestId, async ([FromServices] ICommentRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetIdsByRequestIdAsync(id);
            })
            .WithName(ApiEndpoints.Comment.MetaData.GetByRequestId)
            .Produces(StatusCodes.Status200OK);

            group.MapPost(ApiEndpoints.Comment.Create, async ([FromServices] ICommentRepository rep, [FromBody] CommentModel comment) =>
            {
                return await rep.AddAsync(comment);
            })
            .WithName(ApiEndpoints.Comment.Create)
            .Produces(StatusCodes.Status200OK);

            group.MapPut(ApiEndpoints.Comment.Update, async ([FromServices] ICommentRepository rep, [FromBody] CommentModel comment) =>
            {
                return await rep.UpdateAsync(comment);
            })
            .WithName(ApiEndpoints.Comment.MetaData.Update)
            .Produces(StatusCodes.Status200OK);

            group.MapDelete(ApiEndpoints.Comment.Delete, async ([FromServices] ICommentRepository rep, [FromRoute] string id) =>
            {
                return await rep.DeleteAsync(id);
            })
            .WithName(ApiEndpoints.Comment.MetaData.Delete)
            .Produces(StatusCodes.Status200OK);
        }
    }
}
