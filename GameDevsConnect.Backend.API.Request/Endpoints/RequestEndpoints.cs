using GameDevsConnect.Backend.Shared.DTO;

namespace GameDevsConnect.Backend.API.Request.Endpoints
{
    public static class RequestEndpoints
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/request");

            group.MapGet("", async (IRequestRepository rep) =>
            {
                return await rep.GetIdsAsync();
            });

            // Get Tags by Request Id
            group.MapGet("{id}", async (IRequestRepository rep, string id) =>
            {
                return await rep.GetByIdAsync(id);
            });
            // Get Tags by Request Id
            group.MapGet("full/{id}", async (IRequestRepository rep, string id) =>
            {
                return await rep.GetFullByIdAsync(id);
            });

            // Get Tags by Request Id
            group.MapGet("user/{id}", async (IRequestRepository rep, string id) =>
            {
                return await rep.GetByUserIdAsync(id);
            });

            group.MapPost("add", async(IRequestRepository rep, AddRequestTagsDTO dto) =>
            {
                return await rep.AddAsync(dto.Request, dto.Tags);
            });

            // Update a Tag
            group.MapPut("update", async (IRequestRepository rep, RequestModel request) =>
            {
                return await rep.UpdateAsync(request);
            });

            // Delete a Tag
            group.MapDelete("delete/{id}", async (IRequestRepository rep, string id) =>
            {
                return await rep.DeleteAsync(id);
            });
        }
    }
}
