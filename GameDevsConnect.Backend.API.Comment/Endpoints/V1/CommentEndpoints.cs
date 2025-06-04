namespace GameDevsConnect.Backend.API.Comment.Endpoints.V1
{
    public static class CommentEndpoints
    {
        public static void MapEndpointsV1(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/v1/comment");

            // Get all Comments
            group.MapGet("count/{id}", async ([FromServices] ICommentRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetCountByRequestIdAsync(id);
            });

            // Get Comments by Request Id
            group.MapGet("{id}", async ([FromServices] ICommentRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetByIdAsync(id);
            });

            // Get Comments by Request Id
            group.MapGet("request/{id}", async ([FromServices] ICommentRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetIdsByRequestIdAsync(id);
            });

            // Add a Comment
            group.MapPost("add", async ([FromServices] ICommentRepository rep, [FromBody] CommentModel comment) =>
            {
                return await rep.AddAsync(comment);
            });

            // Update a Comment
            group.MapPut("update", async ([FromServices] ICommentRepository rep, [FromBody] CommentModel comment) =>
            {
                return await rep.UpdateAsync(comment);
            });

            // Delete a Comment
            group.MapDelete("delete/{id}", async ([FromServices] ICommentRepository rep, [FromRoute] string id) =>
            {
                return await rep.DeleteAsync(id);
            });
        }
    }
}
