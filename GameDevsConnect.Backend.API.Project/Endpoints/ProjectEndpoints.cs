namespace GameDevsConnect.Backend.API.Project.Endpoints
{
    public static class ProjectEndpoints
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/project");

            // Get Projects by Request Id
            group.MapGet("", async (IProjectRepository rep) =>
            {
                return await rep.GetIdsAsync();
            });

            // Get Projects by Request Id
            group.MapGet("{id}", async (IProjectRepository rep, string id) =>
            {
                return await rep.GetByIdAsync(id);
            });

            // Add a Project
            group.MapPost("add", async (IProjectRepository rep, ProjectModel Project) =>
            {
                return await rep.AddAsync(Project);
            });

            // Update a Project
            group.MapPut("update", async (IProjectRepository rep, ProjectModel Project) =>
            {
                return await rep.UpdateAsync(Project);
            });

            // Delete a Project
            group.MapDelete("delete/{id}", async (IProjectRepository rep, string id) =>
            {
                return await rep.DeleteAsync(id);
            });
        }
    }
}
