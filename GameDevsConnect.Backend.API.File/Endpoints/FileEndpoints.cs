namespace GameDevsConnect.Backend.API.File.Endpoints
{
    public static class FileEndpoints
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/file");

            // Get all Files
            group.MapGet("owner/{id}", async (IFileRepository rep, string id) =>
            {
                return await rep.GetIdsByOwnerIdAsync(id);
            });

            // Get Files by Request Id
            group.MapGet("{id}", async (IFileRepository rep, int id) =>
            {
                return await rep.GetByIdAsync(id);
            });

            // Get Files by Request Id
            group.MapGet("request/{id}", async (IFileRepository rep, int id) =>
            {
                return await rep.GetByRequestIdAsync(id);
            });

            // Add a File
            group.MapPost("add", async (IFileRepository rep, FileModel File) =>
            {
                return await rep.AddAsync(File);
            });

            // Update a File
            group.MapPut("update", async (IFileRepository rep, FileModel File) =>
            {
                return await rep.UpdateAsync(File);
            });

            // Delete a File
            group.MapDelete("delete/{id}", async (IFileRepository rep, int id) =>
            {
                return await rep.DeleteAsync(id);
            });
        }
    }
}
