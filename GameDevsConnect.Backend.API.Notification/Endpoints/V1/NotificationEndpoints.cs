using GameDevsConnect.Backend.API.Notification.Application.Repository.V1;

namespace GameDevsConnect.Backend.API.Notification.Endpoints.V1
{
    public static class NotificationEndpoints
    {
        public static void MapEndpointsV1(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup(ApiEndpoints.Notification.Group);

            // Get all Notifications
            group.MapGet(ApiEndpoints.Notification.GetCount, async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetUnseenCountAsync(id);
            })
            .WithName(ApiEndpoints.Notification.MetaData.GetCount)
            .Produces(StatusCodes.Status200OK);

            // Get Notifications by Request Id
            group.MapGet(ApiEndpoints.Notification.Get, async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetByIdAsync(id);
            })
            .WithName(ApiEndpoints.Notification.MetaData.Get)
            .Produces(StatusCodes.Status200OK);

            // Get Notifications by Request Id
            group.MapGet(ApiEndpoints.Notification.GetByUserId, async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetIdsByUserIdAsync(id);
            })
            .WithName(ApiEndpoints.Notification.MetaData.GetByUserId)
            .Produces(StatusCodes.Status200OK);

            // Add a Notification
            group.MapPost(ApiEndpoints.Notification.Create, async ([FromServices] INotificationRepository rep, [FromBody] NotificationModel notification) =>
            {
                return await rep.AddAsync(notification);
            })
            .WithName(ApiEndpoints.Notification.MetaData.Create)
            .Produces(StatusCodes.Status200OK);

            // Update a Notification
            group.MapPut(ApiEndpoints.Notification.Update, async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
            {
                return await rep.UpdateAsync(id);
            })
            .WithName(ApiEndpoints.Notification.MetaData.Update)
            .Produces(StatusCodes.Status200OK);

            // Delete a Notification
            group.MapDelete(ApiEndpoints.Notification.Delete, async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
            {
                return await rep.DeleteAsync(id);
            })
            .WithName(ApiEndpoints.Notification.MetaData.Delete)
            .Produces(StatusCodes.Status200OK);
        }
    }
}
