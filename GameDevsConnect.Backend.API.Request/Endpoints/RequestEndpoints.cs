namespace GameDevsConnect.Backend.API.Request.Endpoints
{
    public static class RequestEndpoints
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/request");

            // Get all Tags
            group.MapGet("", async (IRequestRepository rep) =>
            {
                return await rep.GetIdsAsync();
            });

            // Get Tags by Request Id
            group.MapGet("{id}", async (IRequestRepository rep, int id) =>
            {
                return await rep.GetByIdAsync(id);
            });

            // Get Tags by Request Id
            group.MapGet("user/{id}", async (IRequestRepository rep, string id) =>
            {
                return await rep.GetByUserIdAsync(id);
            });

            // Add a Tag
            group.MapPost("add", async (IRequestRepository rep, RequestModel request) =>
            {
                return await rep.AddAsync(request);
            });

            // Update a Tag
            group.MapPut("update", async (IRequestRepository rep, RequestModel request) =>
            {
                return await rep.UpdateAsync(request);
            });

            // Delete a Tag
            group.MapDelete("delete/{id}", async (IRequestRepository rep, int id) =>
            {
                return await rep.DeleteAsync(id);
            });
        }
    }
}
