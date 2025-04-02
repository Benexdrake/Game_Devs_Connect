namespace GameDevsConnect.Backend.API.Notification.Endpoints
{
    public static class NotificationEndpoints
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/notification");

            // Get all Notifications
            group.MapGet("count/{id}", async (INotificationRepository rep, string id) =>
            {
                return await rep.GetUnseenCountAsync(id);
            });

            // Get Notifications by Request Id
            group.MapGet("{id}", async (INotificationRepository rep, string id) =>
            {
                return await rep.GetByIdAsync(id);
            });

            // Get Notifications by Request Id
            group.MapGet("user/{id}", async (INotificationRepository rep, string id) =>
            {
                return await rep.GetIdsByUserIdAsync(id);
            });

            // Add a Notification
            group.MapPost("add", async (INotificationRepository rep, NotificationModel notification) =>
            {
                return await rep.AddAsync(notification);
            });

            // Update a Notification
            group.MapPut("update", async (INotificationRepository rep, string id) =>
            {
                return await rep.UpdateAsync(id);
            });

            // Delete a Notification
            group.MapDelete("delete/{id}", async (INotificationRepository rep, string id) =>
            {
                return await rep.DeleteAsync(id);
            });
        }
    }
}
