namespace GameDevsConnect.Backend.API.Notification.Endpoints.V1;

public static class NotificationEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.User.Group)
                       .WithApiVersionSet(apiVersionSet);

        // Get all Notifications
        group.MapGet(ApiEndpointsV1.Notification.GetCount, async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetUnseenCountAsync(id);
        })
        .WithName(ApiEndpointsV1.Notification.MetaData.GetCount)
        .Produces(StatusCodes.Status200OK);

        // Get Notifications by Request Id
        group.MapGet(ApiEndpointsV1.Notification.Get, async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetByIdAsync(id);
        })
        .WithName(ApiEndpointsV1.Notification.MetaData.Get)
        .Produces(StatusCodes.Status200OK);

        // Get Notifications by Request Id
        group.MapGet(ApiEndpointsV1.Notification.GetByUserId, async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetIdsByUserIdAsync(id);
        })
        .WithName(ApiEndpointsV1.Notification.MetaData.GetByUserId)
        .Produces(StatusCodes.Status200OK);

        // Add a Notification
        group.MapPost(ApiEndpointsV1.Notification.Create, async ([FromServices] INotificationRepository rep, [FromBody] NotificationModel notification) =>
        {
            return await rep.AddAsync(notification);
        })
        .WithName(ApiEndpointsV1.Notification.MetaData.Create)
        .Produces(StatusCodes.Status200OK);

        // Update a Notification
        group.MapPut(ApiEndpointsV1.Notification.Update, async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
        {
            return await rep.UpdateAsync(id);
        })
        .WithName(ApiEndpointsV1.Notification.MetaData.Update)
        .Produces(StatusCodes.Status200OK);

        // Delete a Notification
        group.MapDelete(ApiEndpointsV1.Notification.Delete, async ([FromServices] INotificationRepository rep, [FromRoute] string id) =>
        {
            return await rep.DeleteAsync(id);
        })
        .WithName(ApiEndpointsV1.Notification.MetaData.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
