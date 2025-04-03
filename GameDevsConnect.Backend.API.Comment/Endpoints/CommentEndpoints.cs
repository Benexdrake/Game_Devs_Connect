namespace GameDevsConnect.Backend.API.Comment.Endpoints
{
    public static class CommentEndpoints
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/comment");

            // Get all Comments
            group.MapGet("count/{id}", async (ICommentRepository rep, string id) =>
            {
                return await rep.GetCountByParentIdAsync(id);
            });

            // Get Comments by Request Id
            group.MapGet("{id}", async (ICommentRepository rep, string id) =>
            {
                return await rep.GetByIdAsync(id);
            });

            // Get Comments by Request Id
            group.MapGet("request/{id}", async (ICommentRepository rep, string id) =>
            {
                return await rep.GetByParentsIdAsync(id);
            });

            // Add a Comment
            group.MapPost("add", async (ICommentRepository rep, CommentModel comment) =>
            {
                return await rep.AddAsync(comment);
            });

            // Update a Comment
            group.MapPut("update", async (ICommentRepository rep, CommentModel comment) =>
            {
                return await rep.UpdateAsync(comment);
            });

            // Delete a Comment
            group.MapDelete("delete/{id}", async (ICommentRepository rep, string id) =>
            {
                return await rep.DeleteAsync(id);
            });
        }
    }
}
