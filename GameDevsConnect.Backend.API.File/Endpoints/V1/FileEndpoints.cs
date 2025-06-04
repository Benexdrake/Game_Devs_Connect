using GameDevsConnect.Backend.API.File.Application.Repository.V1;

namespace GameDevsConnect.Backend.API.File.Endpoints.V1
{
    public static class FileEndpoints
    {
        public static void MapEndpointsV1(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/v1/file");

            // Get all Files
            group.MapGet("owner/{id}", async ([FromServices] IFileRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetIdsByOwnerIdAsync(id);
            });

            // Get File by Id
            group.MapGet("{id}", async ([FromServices] IFileRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetByIdAsync(id);
            });

            // Get Files by Request Id
            group.MapGet("request/{id}", async ([FromServices] IFileRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetByRequestIdAsync(id);
            });

            // Add a File
            group.MapPost("add", async ([FromServices] IFileRepository rep, [FromBody] FileModel File) =>
            {
                return await rep.AddAsync(File);
            });

            // Update a File
            group.MapPut("update", async ([FromServices] IFileRepository rep, [FromBody] FileModel File) =>
            {
                return await rep.UpdateAsync(File);
            });

            // Delete a File
            group.MapDelete("delete/{id}", async ([FromServices] IFileRepository rep, [FromRoute] string id) =>
            {
                return await rep.DeleteAsync(id);
            });
        }
    }
}
