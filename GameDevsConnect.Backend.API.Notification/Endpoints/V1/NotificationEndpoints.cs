using GameDevsConnect.Backend.API.Notification.Application.Repository.V1;

namespace GameDevsConnect.Backend.API.Notification.Endpoints.V1
{
    public static class NotificationEndpoints
    {
        public static void MapEndpointsV1(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/v1/notification");

            // Get all Notifications
            group.MapGet("count/{id}", async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetUnseenCountAsync(id);
            });

            // Get Notifications by Request Id
            group.MapGet("{id}", async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetByIdAsync(id);
            });

            // Get Notifications by Request Id
            group.MapGet("user/{id}", async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
            {
                return await rep.GetIdsByUserIdAsync(id);
            });

            // Add a Notification
            group.MapPost("add", async ([FromServices] INotificationRepository rep, [FromBody] NotificationModel notification) =>
            {
                return await rep.AddAsync(notification);
            });

            // Update a Notification
            group.MapPut("update/{id}", async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
            {
                return await rep.UpdateAsync(id);
            });

            // Delete a Notification
            group.MapDelete("delete/{id}", async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
            {
                return await rep.DeleteAsync(id);
            });
        }
    }
}
