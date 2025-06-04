using GameDevsConnect.Backend.API.File.Application.Repository.V1;

namespace GameDevsConnect.Backend.API.File.Endpoints.V1
{
    public static class FileEndpoints
    {
        public static void MapEndpointsV1(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup(ApiEndpoints.File.Group);

            group.MapGet(ApiEndpoints.File.GetByOwnerId, async ([FromServices] IFileRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetIdsByOwnerIdAsync(id);
            })
            .WithName(ApiEndpoints.File.MetaData.GetByOwnerId)
            .Produces(StatusCodes.Status200OK);

            group.MapGet(ApiEndpoints.File.Get, async ([FromServices] IFileRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetByIdAsync(id);
            })
            .WithName(ApiEndpoints.File.MetaData.Get)
            .Produces(StatusCodes.Status200OK);

            group.MapGet(ApiEndpoints.File.GetByRequestId, async ([FromServices] IFileRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetByRequestIdAsync(id);
            })
            .WithName(ApiEndpoints.File.MetaData.GetByRequestId)
            .Produces(StatusCodes.Status200OK);

            group.MapPost(ApiEndpoints.File.Create, async ([FromServices] IFileRepository rep, [FromBody] FileModel File) =>
            {
                return await rep.AddAsync(File);
            })
            .WithName(ApiEndpoints.File.MetaData.Create)
            .Produces(StatusCodes.Status200OK);

            group.MapPut(ApiEndpoints.File.Update, async ([FromServices] IFileRepository rep, [FromBody] FileModel File) =>
            {
                return await rep.UpdateAsync(File);
            })
            .WithName(ApiEndpoints.File.MetaData.Update)
            .Produces(StatusCodes.Status200OK);

            group.MapDelete(ApiEndpoints.File.Delete, async ([FromServices] IFileRepository rep, [FromRoute] string id) =>
            {
                return await rep.DeleteAsync(id);
            })
            .WithName(ApiEndpoints.File.MetaData.Delete)
            .Produces(StatusCodes.Status200OK);
        }
    }
}
