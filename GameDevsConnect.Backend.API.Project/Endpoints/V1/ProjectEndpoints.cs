using GameDevsConnect.Backend.API.Project.Contract.Requests;

namespace GameDevsConnect.Backend.API.Project.Endpoints.V1
{
    public static class ProjectEndpoints
    {
        public static void MapEndpointsV1(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/v1/project");

            // Get Projects by Request Id
            group.MapGet("", async ([FromServices] IProjectRepository repo) =>
            {
                return await repo.GetIdsAsync();
            });

            // Get Projects by Request Id
            group.MapGet("{id}", async ([FromServices] IProjectRepository repo, [FromRoute] string id) =>
            {
                return await repo.GetByIdAsync(id);
            });

            // Add a Project
            group.MapPost("add", async ([FromServices] IProjectRepository repo, [FromBody] UpsertRequest addRequest) =>
            {
                return await repo.AddAsync(addRequest);
            });

            // Update a Project
            group.MapPut("update", async ([FromServices] IProjectRepository repo, [FromBody] UpsertRequest updateRequest) =>
            {
                return await repo.UpdateAsync(updateRequest);
            });

            // Delete a Project
            group.MapDelete("delete/{id}", async ([FromServices] IProjectRepository repo, [FromRoute] string id) =>
            {
                return await repo.DeleteAsync(id);
            });
        }
    }
}
